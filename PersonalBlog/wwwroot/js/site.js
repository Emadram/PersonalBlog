// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Dark mode functionality
document.addEventListener('DOMContentLoaded', () => {
    const themeToggle = document.getElementById('theme-toggle');
    const htmlElement = document.documentElement;
    
    // Check for saved user preference
    const savedTheme = localStorage.getItem('theme');
    if (savedTheme) {
        htmlElement.setAttribute('data-theme', savedTheme);
        if (themeToggle) {
            updateToggleIcon(savedTheme === 'dark');
        }
        updateComponentsForTheme(savedTheme);
    } else {
        // Check for OS preference
        const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
        if (prefersDark) {
            htmlElement.setAttribute('data-theme', 'dark');
            if (themeToggle) {
                updateToggleIcon(true);
            }
            updateComponentsForTheme('dark');
        }
    }
    
    // Toggle theme when button is clicked
    if (themeToggle) {
        themeToggle.addEventListener('click', () => {
            const currentTheme = htmlElement.getAttribute('data-theme');
            const newTheme = currentTheme === 'dark' ? 'light' : 'dark';
            
            htmlElement.setAttribute('data-theme', newTheme);
            localStorage.setItem('theme', newTheme);
            updateToggleIcon(newTheme === 'dark');
            updateComponentsForTheme(newTheme);
        });
    }
    
    // Update the icon based on current theme
    function updateToggleIcon(isDark) {
        if (!themeToggle) return;
        const iconElement = themeToggle.querySelector('i');
        if (iconElement) {
            iconElement.className = isDark ? 'fas fa-sun' : 'fas fa-moon';
        }
    }
    
    // Update specific components that require JS modifications for theme changes
    function updateComponentsForTheme(theme) {
        const isDark = theme === 'dark';
        
        // Update navbar if it has theme-specific classes
        const navbar = document.querySelector('.navbar');
        if (navbar) {
            if (isDark) {
                navbar.classList.remove('navbar-light');
                navbar.classList.add('navbar-dark');
            } else {
                navbar.classList.remove('navbar-dark');
                navbar.classList.add('navbar-light');
            }
        }
        
        // Update any component that needs explicit class changes
        document.querySelectorAll('.bg-white, .bg-dark').forEach(el => {
            if (isDark) {
                el.classList.remove('bg-white');
                el.classList.add('bg-dark');
            } else {
                el.classList.remove('bg-dark');
                el.classList.add('bg-white');
            }
        });
        
        // Update text color classes if needed
        document.querySelectorAll('.text-white, .text-dark').forEach(el => {
            // Only update elements that don't have a persistent color class
            if (!el.classList.contains('text-always-dark') && !el.classList.contains('text-always-white')) {
                if (isDark) {
                    el.classList.remove('text-dark');
                    el.classList.add('text-white');
                } else {
                    el.classList.remove('text-white');
                    el.classList.add('text-dark');
                }
            }
        });
        
        // Dispatch a custom event for other components that need to react
        document.dispatchEvent(new CustomEvent('themeChanged', { detail: { theme } }));
    }
    
    // Listen for system preference changes
    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', e => {
        if (localStorage.getItem('theme') === null) {
            const newTheme = e.matches ? 'dark' : 'light';
            htmlElement.setAttribute('data-theme', newTheme);
            updateToggleIcon(e.matches);
            updateComponentsForTheme(newTheme);
        }
    });
});
