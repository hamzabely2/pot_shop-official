import  { useEffect, useState } from 'react';
import axios, { AxiosResponse, AxiosError } from 'axios';

export const GetAllItem = () => {
    const [data, setData] = useState<any>(null); // Utilisation de "any" pour data
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<AxiosError | null>(null); // Utilisation de "any" pour error

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response: AxiosResponse = await axios.get(`${process.env.REACT_APP_URL}item`);
                setData(response.data.result);
                setLoading(false);
            } catch (err : any) {
                setError(err);
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    return { data, loading, error };
};
export const GetItem = (id : any) => {
    const [data, setData] = useState<any>(null); // Utilisation de "any" pour data
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<AxiosError | null>(null); // Utilisation de "any" pour error

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response: AxiosResponse = await axios.get(`${process.env.REACT_APP_URL}item/${id}`);
                setData(response.data.result);
                setLoading(false);
            } catch (err : any) {
                setError(err);
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    return { data, loading, error };
};