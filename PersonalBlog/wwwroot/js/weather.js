// Weather Widget JavaScript
document.addEventListener('DOMContentLoaded', function() {
    // Only try to get geolocation if the weather widget exists on the page
    const weatherWidget = document.querySelector('#weatherWidget');
    if (!weatherWidget) return;

    const MAX_UPDATES = 2; // Limit to 2 refreshes
    const COOLDOWN_PERIOD_MS = 5 * 60 * 1000; // 5 minutes
    const API_RESPONSE_DELAY_MS = 3000; // 3 seconds

    // Function to get rate limit status from localStorage
    function getRateLimitStatus() {
        const count = parseInt(localStorage.getItem('weatherUpdateCount') || '0');
        const lastTime = parseInt(localStorage.getItem('weatherLastUpdateTime') || '0');
        return { count, lastTime };
    }

    // Function to update rate limit status in localStorage
    function updateRateLimitStatus(increment = true) {
        let { count } = getRateLimitStatus();
        if (increment) {
            count++;
        }
        localStorage.setItem('weatherUpdateCount', count.toString());
        localStorage.setItem('weatherLastUpdateTime', Date.now().toString());
        return count;
    }

    // Function to reset rate limit count
    function resetRateLimitCount() {
        localStorage.setItem('weatherUpdateCount', '0');
    }

    // Handle temperature unit conversion
    setupTemperatureUnitToggle();

    // Function to update weather based on coordinates
    function updateWeatherByCoordinates(lat, lon) {
        // Store coordinates in localStorage for future use
        localStorage.setItem('weather-lat', lat);
        localStorage.setItem('weather-lon', lon);

        weatherWidget.classList.add('weather-loading');
        
        setTimeout(() => {
            fetch(`${window.location.origin}/api/Weather/coordinates?lat=${lat}&lon=${lon}`)
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`Server returned ${response.status}: ${response.statusText}`);
                    }
                    return response.json();
                })
                .then(data => {
                    if (data.success) {
                        console.log('Weather data updated successfully with coordinates');
                        updateRateLimitStatus();
                        location.reload();
                    } else {
                        console.warn('Weather coordinates update returned success: false. Message:', data.message);
                        alert('Could not update weather at this time. ' + (data.message || ''));
                    }
                })
                .catch(error => {
                    console.error('Error fetching weather data:', error);
                    alert('Error fetching weather data. Please try again later.');
                })
                .finally(() => {
                    weatherWidget.classList.remove('weather-loading');
                });
        }, API_RESPONSE_DELAY_MS);
    }

    // Try to get the user's current location
    if (navigator.geolocation) {
        const lastGeolocationRequest = localStorage.getItem('lastGeolocationRequest');
        const oneHourAgo = Date.now() - (60 * 60 * 1000);

        if (!lastGeolocationRequest || parseInt(lastGeolocationRequest) < oneHourAgo) {
            navigator.geolocation.getCurrentPosition(
                function(position) {
                    localStorage.setItem('lastGeolocationRequest', Date.now().toString());
                    const latitude = position.coords.latitude;
                    const longitude = position.coords.longitude;
                    // Initial update via geolocation bypasses manual click rate limit but uses its own 1-hour check
                    updateWeatherByCoordinates(latitude, longitude);
                },
                function(error) {
                    console.log('Geolocation error:', error.message);
                    // If geolocation fails or is denied, and no stored coords, try a refresh to get default.
                    // This will be subject to rate limiting if clicked.
                    if (!localStorage.getItem('weather-lat') || !localStorage.getItem('weather-lon')) {
                        // Trigger a refresh on first load if geo fails and no coords exist
                        // but don't force it if user manually clicks later.
                        // This initial call won't count towards rate limit as it's auto.
                        console.log('Attempting initial refresh due to geolocation failure and no stored coordinates.');
                        // We can call the refresh logic directly here, but it's simpler to just log
                        // and let the user click if they wish, or rely on existing displayed data if any.
                    }
                },
                {
                    enableHighAccuracy: false,
                    timeout: 5000,
                    maximumAge: 3600000
                }
            );
        }
    }

    // Add click handler to the weather widget to refresh weather data
    // Create a tooltip element for the cooldown message
    const cooldownTooltip = document.createElement('div');
    cooldownTooltip.className = 'weather-cooldown-tooltip';
    cooldownTooltip.style.display = 'none';
    cooldownTooltip.style.position = 'absolute';
    cooldownTooltip.style.backgroundColor = 'rgba(0, 0, 0, 0.8)';
    cooldownTooltip.style.color = 'white';
    cooldownTooltip.style.padding = '5px 10px';
    cooldownTooltip.style.borderRadius = '4px';
    cooldownTooltip.style.fontSize = '14px';
    cooldownTooltip.style.zIndex = '1000';
    document.body.appendChild(cooldownTooltip);

    // Function to check and update the button's state based on rate limit
    function updateWeatherButtonState() {
        let { count, lastTime } = getRateLimitStatus();
        const currentTime = Date.now();
        const isOnCooldown = count >= MAX_UPDATES && currentTime - lastTime < COOLDOWN_PERIOD_MS;
        
        if (isOnCooldown) {
            // Button is on cooldown
            weatherWidget.classList.add('weather-cooldown');
            weatherWidget.style.opacity = '0.8'; // Increased from 0.6 to make it more readable when disabled
            weatherWidget.style.cursor = 'not-allowed';
            
            // Calculate time left
            const msLeft = COOLDOWN_PERIOD_MS - (currentTime - lastTime);
            const minutesLeft = Math.floor(msLeft / 60000);
            const secondsLeft = Math.floor((msLeft % 60000) / 1000);
            
            // Set the tooltip text
            cooldownTooltip.textContent = `On cooldown: ${minutesLeft}m ${secondsLeft}s remaining`;
        } else {
            // Button is active
            weatherWidget.classList.remove('weather-cooldown');
            weatherWidget.style.opacity = '1';
            weatherWidget.style.cursor = 'pointer';
            
            if (count >= MAX_UPDATES) {
                // Reset count if cooldown period has passed
                resetRateLimitCount();
            }
        }
        
        // Update every second if on cooldown
        if (isOnCooldown) {
            setTimeout(updateWeatherButtonState, 1000);
        }
    }
    
    // Initial check of button state
    updateWeatherButtonState();
    
    // Show/hide tooltip on hover
    weatherWidget.addEventListener('mouseenter', function(e) {
        if (weatherWidget.classList.contains('weather-cooldown')) {
            const rect = weatherWidget.getBoundingClientRect();
            cooldownTooltip.style.left = `${rect.left}px`;
            cooldownTooltip.style.top = `${rect.bottom + 5}px`;
            cooldownTooltip.style.display = 'block';
        }
    });
    
    weatherWidget.addEventListener('mouseleave', function() {
        cooldownTooltip.style.display = 'none';
    });

    weatherWidget.addEventListener('click', function() {
        let { count, lastTime } = getRateLimitStatus();

        // Check if on cooldown
        if (count >= MAX_UPDATES) {
            if (Date.now() - lastTime < COOLDOWN_PERIOD_MS) {
                // Don't do anything if on cooldown - the tooltip will show on hover
                return;
            } else {
                resetRateLimitCount();
                count = 0; // Reset count for current operation
            }
        }

        this.classList.add('weather-loading');

        setTimeout(() => {
            const lat = localStorage.getItem('weather-lat');
            const lon = localStorage.getItem('weather-lon');

            let fetchPromise;
            if (lat && lon) {
                fetchPromise = fetch(`${window.location.origin}/api/Weather/coordinates?lat=${lat}&lon=${lon}`);
            } else {
                fetchPromise = fetch(`${window.location.origin}/api/Weather/refresh`);
            }

            fetchPromise
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`Server returned ${response.status}: ${response.statusText}`);
                    }
                    return response.json();
                })
                .then(data => {
                    if (data.success) {
                        console.log('Weather data refreshed successfully');
                        updateRateLimitStatus(); // Increment count and update time
                        location.reload();
                    } else {
                        console.warn('Weather refresh returned success: false. Message:', data.message);
                        alert('Could not refresh weather at this time. ' + (data.message || ''));
                    }
                })
                .catch(error => {
                    console.error('Error refreshing weather:', error);
                    alert('Error refreshing weather. Please try again later.');
                })
                .finally(() => {
                    this.classList.remove('weather-loading');
                });
        }, API_RESPONSE_DELAY_MS);
    });

    // Function to handle temperature unit conversion
    function setupTemperatureUnitToggle() {
        const tempUnitC = document.querySelector('.temp-unit-c');
        const tempUnitF = document.querySelector('.temp-unit-f');
        
        if (!tempUnitC || !tempUnitF) return;

        // Store original Celsius values from the DOM on first load if not already stored
        // This assumes the server initially renders in Celsius.
        document.querySelectorAll('.weather-detail-row span[data-temp-c]').forEach(el => {
            if (!el.dataset.originalCelsius) {
                el.dataset.originalCelsius = parseFloat(el.textContent);
            }
        });

        const savedUnit = localStorage.getItem('temp-unit') || 'c';
        updateActiveButton(savedUnit);
        convertTemperaturesTo(savedUnit, true);

        tempUnitC.addEventListener('click', function() {
            if (localStorage.getItem('temp-unit') === 'c') return;
            localStorage.setItem('temp-unit', 'c');
            updateActiveButton('c');
            convertTemperaturesTo('c');
        });

        tempUnitF.addEventListener('click', function() {
            if (localStorage.getItem('temp-unit') === 'f') return;
            localStorage.setItem('temp-unit', 'f');
            updateActiveButton('f');
            convertTemperaturesTo('f');
        });
    }

    function updateActiveButton(unit) {
        const tempUnitC = document.querySelector('.temp-unit-c');
        const tempUnitF = document.querySelector('.temp-unit-f');
        if (unit === 'f') {
            tempUnitC.classList.remove('active');
            tempUnitF.classList.add('active');
        } else {
            tempUnitF.classList.remove('active');
            tempUnitC.classList.add('active');
        }
    }

    // Function to convert temperatures displayed in the tooltip
    function convertTemperaturesTo(targetUnit, isInitialLoad = false) {
        // Convert main display temperature (outside tooltip)
        const mainTempElement = document.querySelector('.weather-widget .fw-bold');
        if (mainTempElement) {
            processTemperatureElement(mainTempElement, targetUnit, isInitialLoad, true);
        }

        // Convert tooltip temperatures
        const tempElements = document.querySelectorAll('.weather-detail-row span:last-child');
        tempElements.forEach(element => {
            processTemperatureElement(element, targetUnit, isInitialLoad, false);
        });
    }

    function processTemperatureElement(element, targetUnit, isInitialLoad, isMainDisplay) {
        const text = element.textContent.trim();
        const currentUnitSymbol = text.includes('°C') ? '°C' : (text.includes('°F') ? '°F' : null);
        let tempValue = parseFloat(text.replace('°C', '').replace('°F', ''));

        if (isNaN(tempValue) || !currentUnitSymbol) return; // Not a temperature element we can process

        let originalCelsius;
        // For main display, we need to store its original C value if not already done.
        // For tooltip, Default.cshtml should provide data-temp-c for feels like.
        // For the primary temp, it's from Model.FormattedTemperature which is already unit-suffixed.

        if (isInitialLoad) {
            if (currentUnitSymbol === '°C') {
                element.dataset.originalCelsius = tempValue;
            } else if (currentUnitSymbol === '°F') {
                // If loaded as °F (e.g. preference was °F), convert back to C for storage
                element.dataset.originalCelsius = (tempValue - 32) * 5/9;
            }
        }
        
        originalCelsius = parseFloat(element.dataset.originalCelsius);
        if (isNaN(originalCelsius)) return; // If no original C value, cannot reliably convert

        let newTemp;
        let newUnitSymbol;

        if (targetUnit === 'f') {
            if (currentUnitSymbol === '°F' && !isInitialLoad) return; // Already °F, no change needed unless initial load
            newTemp = (originalCelsius * 9/5) + 32;
            newUnitSymbol = '°F';
        } else { // targetUnit === 'c'
            if (currentUnitSymbol === '°C' && !isInitialLoad) return; // Already °C, no change needed unless initial load
            newTemp = originalCelsius;
            newUnitSymbol = '°C';
        }
        element.textContent = Math.round(newTemp) + newUnitSymbol;
         // For the main display, ensure the (Description) part is not lost
        if (isMainDisplay && element.nextElementSibling && element.nextElementSibling.tagName === 'SMALL') {
            // This logic assumes the temperature span is immediately followed by the description small tag
            // This might need adjustment based on exact HTML structure if primary temp is complex
        }
    }
});
