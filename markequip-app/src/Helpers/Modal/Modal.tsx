import React, { Children } from 'react';
import ReactDOM from 'react-dom';
import './modal.css'
const portalRoot = document.getElementById('portal-root')!;

function Modal({children, isOpen, onClickClose} : any){
    if(!isOpen){
        return null;
    }

    return ReactDOM.createPortal(
        <div className="modal-overlay">
            <div className="modal">
           <button type="button" className="modal_close-button"  onClick={onClickClose}>X</button>
            {children}
            </div>
        </div>,
        
        portalRoot,
    );
};

export default Modal;