import axios from "axios";

export const getImages = (count = 15) => {
    return axios.get(`https://localhost:5001/api/file/random?count=${count}`);
};