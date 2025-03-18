import { useState, useEffect } from "react"; 
const Products = () => {
	 const [products, setProducts] = useState([]); 
	 useEffect(() => { fetch("http://localhost:5000/api/products", { 
		headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
	 }) 
	 .then((res) => res.json()) 
	 .then((data) => setProducts(data)); },
	  []);
	   return ( 
	   <div> 
	   <h2>Products</h2> 
	   <ul>{products.map((product, index) => <li key={index}>{product}</li>)}</ul> 
	   </div> 
	   ); 
	}; 
	export default Products;