import { useState } from 'react';
import useDebounce from './useDebounce';


const SearchInput = ({value, onChange} : any) =>{
    const [displayValue, setDisplayValue] = useState(value);
    const debouncedChange = useDebounce(onChange, 500);

    function handleChange(e: { target: HTMLInputElement }){
        setDisplayValue(e.target.value);
        debouncedChange(e.target.value);
    }

    return(
        <input 
        type="search"
        placeholder="Digite aqui para buscar" 
        value ={displayValue}
        onChange={handleChange}/>
    );
}

export default SearchInput;