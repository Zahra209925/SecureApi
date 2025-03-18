import { useState } from "react";
const Login = () =>
{
const [username, setUsername] = useState("");
const [password, setPassword] = useState("");
const [token, setToken] = useState(null);

const handleLogin = async () =>
{
const response = await fetch("http://localhost:5000/api/auth/login",{
    method: "POST",
	headers: { "Content-Type": "application/json" }, 
	body: JSON.stringify({ username, password }), 
	});
const data = await response.json();
if (data.token)
{
	setToken(data.token);
	localStorage.setItem("token", data.token);
} 
				};
return (

< div >

 < h2 > Login </ h2 >

  < input type = "text" placeholder = "admin" onChange ={ (e) => setUsername(e.target.value)} />

  < input type = "password" placeholder = "1234" onChange ={ (e) => setPassword(e.target.value)} />

  < button onClick ={ handleLogin}> Login </ button >

   </ div >
				   ); 
				};
export default Login;