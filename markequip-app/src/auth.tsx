import { validateToken } from "./Services/api";
import jwt from 'jwt-decode'

export const IsAuthenticated = async () => {
  const tokenUser = localStorage.getItem("Token")!;
  const validate = {
       headers: {
            token: tokenUser
       }
  };

  if (!!tokenUser) {
    try {
      const result = await validateToken(validate);
      return result.data;
    } catch (error) {
      console.log("Invalid Token");
    }
  }
  return false;
};


export function decodeJWT() {  
  var token = localStorage.getItem('Token')!;
   var tokenJwt = token.replace('Bearer','')
  let decode  = jwt<{role: string}>(tokenJwt)
  return decode.role;
}
