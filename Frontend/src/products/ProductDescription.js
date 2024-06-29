import useGetRequest from "../api/Requests";

export default function ProductDescription(props) {
  const data = useGetRequest(`/product/${props["id"]}`);

  return (
    <>
      <h1>{data["name"]}</h1>
      <h2>{data["description"]}</h2>
    </>
  );
}
