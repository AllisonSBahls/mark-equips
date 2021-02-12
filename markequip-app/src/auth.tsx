export const isAuthenticated = () => (
     !!localStorage.getItem('Token')
)
