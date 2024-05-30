/**
 * Checks if a given token is expired.
 * @param {string} token - The JWT token.
 * @returns {boolean} - Returns true if the token is expired or invalid, false otherwise.
 */
export function isTokenExpired(token) {
    if (!token) return true;
  
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const expiry = payload.exp * 1000; // Convert to milliseconds
      return Date.now() > expiry;
    } catch (error) {
      console.error('Failed to parse token payload:', error);
      return true;
    }
}
  
/**
 * Retrieves the JWT token from localStorage.
 * @returns {string|null} - The JWT token or null if not found.
 */
export function getToken() {
return localStorage.getItem('jwtToken');
}

/**
 * Stores the JWT token in localStorage.
 * @param {string} token - The JWT token.
 */
export function setToken(token) {
localStorage.setItem('jwtToken', token);
}

/**
 * Removes the JWT token from localStorage.
 */
export function removeToken() {
localStorage.removeItem('jwtToken');
}

/**
 * Checks the token expiration and regenerates the token if necessary.
 */
export async function checkTokenExpiration() {
    const token = getToken();
    if (isTokenExpired(token)) {
        alert('Token has expired. Generating a new token.');
        await generateToken(); // Regenerate token
    }
}

/**
 * Generates a new JWT token from the server and stores it.
 */
export async function generateToken() {
    try {
        const apiUrl = process.env.VUE_APP_API_BASE_URL || 'https://localhost:5001'; // Default URL if not provided in environment
        const response = await fetch(`${apiUrl}/generate`);
        if (!response.ok) {
            throw new Error('Failed to fetch new token');
        }

        const data = await response.json();
        if (data.token) {
            setToken(data.token);
            console.log('Token obtained:', data.token);
        } else {
            console.error('Failed to obtain token');
            alert('Failed to obtain token');
        }
    } catch (error) {
        console.error('Error:', error);
        alert('Server is not running.');
    }
}
