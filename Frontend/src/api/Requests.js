import { useEffect, useState } from "react";

export default function useGetRequest(url) {
    const [data, setData] = useState([]);

    useEffect(() => {
        fetch(url, {
            headers: {
                'Content-Type': 'application/json',
            },
        })
            .then((res) => res.json())
            .then((res) => {
                setData(res);
            });
    }, [url]);

    return data;
}
