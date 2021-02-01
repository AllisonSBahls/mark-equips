import React, { Children } from 'react';
import ReactDOM from 'react-dom';
import './modal.css'
const portalRoot = document.getElementById('portal-root')!;

const ModalSchedule = ({children} : any) => {
    return ReactDOM.createPortal(
        <div className="modal-overlay">
            <div className="modal">
                <button type="button" className="modal_close-button">X</button>
                {children}
            </div>
        </div>,
        
        portalRoot,
    );
};

export default ModalSchedule;