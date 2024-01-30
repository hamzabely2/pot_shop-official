import React, { useEffect, useState } from 'react';
import axios from 'axios';

export const GetAllItem = () => {
    const [data, setData] = useState(null); // Utilisation de "any" pour data
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null); // Utilisation de "any" pour error

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`${process.env.REACT_APP_URL}item`);
                setData(response.data.result);
                setLoading(false);
            } catch (err) {
                setError(err);
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    return { data, loading, error };
};

export const GetItem = (id) => {
    const [data, setData] = useState(null); // Utilisation de "any" pour data
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null); // Utilisation de "any" pour error

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`${process.env.REACT_APP_URL}item/${id}`);
                setData(response.data.result);
                setLoading(false);
            } catch (err) {
                setError(err);
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    return { data, loading, error };
};
