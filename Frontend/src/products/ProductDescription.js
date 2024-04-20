import useGetRequest from "../api/Requests";

export default function ProductDescription(props) {
  const data = useGetRequest(`http://localhost:5164/api/Product/${props["id"]}`);

  return (
    <>
      <h1>{data["name"]}</h1>
      <h2>{data["description"]}</h2>
    </>
  );
}
