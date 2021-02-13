import { validateToken } from "./Services/api";

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
