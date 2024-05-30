export function isTokenExpired(token) {
    if (!token) return true;
  
    const payload = JSON.parse(atob(token.split('.')[1]));
    const expiry = payload.exp * 1000; // Convert to milliseconds
    return Date.now() > expiry;
  }
  
  export function getToken() {
    return localStorage.getItem('jwtToken');
  }
  
  export function setToken(token) {
    localStorage.setItem('jwtToken', token);
  }
  
  export function removeToken() {
    localStorage.removeItem('jwtToken');
  }
  
  export function checkTokenExpiration() {
    const token = getToken();
    if (isTokenExpired(token)) {
      alert('Token has expired. Generating a new token.');
      generateToken(); // Regenerate token
    }
  }
  
  export function generateToken() {
    fetch('https://localhost:5001/generate')
      .then(response => response.json())
      .then(data => {
        if (data.token) {
          setToken(data.token);
          console.log('Token obtained:', data.token);
        } else {
          console.error('Failed to obtain token');
          alert('Failed to obtain token');
        }
      })
      .catch(error => {
        console.error('Error:', error);
        alert('Server is not running.');
    });
  }
  