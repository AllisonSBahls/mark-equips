import React, { Children } from 'react';
import ReactDOM from 'react-dom';
import './modal.css'
const portalRoot = document.getElementById('portal-root')!;

const ModalSchedule = ({children, isOpen, onClickClose, onClose} : any) => {
    if(!isOpen){
        return null;
    }

    return ReactDOM.createPortal(
        <div className="modal-overlay">
            <div className="modal">
            {console.log(onClickClose)}     
            {console.log(onClose)}     
           <button type="button" className="modal_close-button"  onClick={onClickClose}>X</button>
            {children}
            </div>
        </div>,
        
        portalRoot,
    );
};

export default ModalSchedule;