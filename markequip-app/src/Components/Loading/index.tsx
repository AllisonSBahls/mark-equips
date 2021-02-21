import "./loading.css"

export default function IsLoading(){
    return(
        <div className="loader"></div>
        
    )
}

export function SpinnerLoading(){
    return(
        <div className="spinner"></div>
    )
}

export function SpinnerLogin(){
    return(
        <div className="spinner-login"></div>
    )
}

export function LoadingPage(){
    return(
        <div className="loader-page">
            <div className="loader-page-spinner"></div>
            <h1>Carregando</h1>
        </div>
    )
}