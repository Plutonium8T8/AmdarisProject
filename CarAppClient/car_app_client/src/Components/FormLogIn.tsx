import { Button, Grid, TextField } from "@mui/material";
import { useState } from "react";
import { useCookies } from "react-cookie";
import * as yup from 'yup';

const loginDefaultValues = {
    username: "",
    password: ""
};

const schema = yup.object(
    {
        username : yup.string().required('Login is required'),
        password : yup.string().required('Login is required').min(8, 'Password must be longer than 8.').max(20, 'Password must be shorter than 20.'),
    })

const FormLogIn = () =>
{
    const [loginValues, setFormValues] = useState(loginDefaultValues);
    
    const [cookies, setCookie, removeCookie] = useCookies(['token']);

    const handleSubmit = async (event: { preventDefault: () => void; }) => {
        event.preventDefault();
        await schema.isValid(loginValues)
        .then((valid) => 
        {
            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");

            var raw = JSON.stringify(loginValues);

            var requestOptions : RequestInit = {
                method: 'POST',
                headers: myHeaders,
                body: raw,
                redirect: 'follow'
              };
            
            fetch("http://127.0.0.1:5000/auth/login", requestOptions)
            .then(response => response.json())
            .then(result => 
            {
                setCookie("token", result.token) 
            })
            .catch(error => console.log('error', error));
        })
        .catch((err) => {
            console.log(err.name);
            console.log(err.errors);
        })
    };

    const handleInputChange = (e: { target: { name: any; value: any; }; }) => {
        const { name, value } = e.target;
        setFormValues({
        ...loginValues,
        [name]: value,
        });
    };

    return(
        <div>
            <form onSubmit={handleSubmit}>
                <Grid container>
                    <Grid item xs={12} className="FormInputs">
                        <TextField className='FormTextField'
                            id="username-input"
                            name="username"
                            label="Username"
                            type="text"
                            value={loginValues.username}
                            onChange={handleInputChange}
                            fullWidth
                        />
                    </Grid>
                    <Grid item xs={12} className="FormInputs">
                        <TextField className='FormTextField'
                            id="outlined-password-input"
                            name="password"
                            label="Password"
                            type="password"
                            value={loginValues.password}
                            onChange={handleInputChange}
                            fullWidth
                        />
                    </Grid>
                    <Grid item  xs={12}>
                        <Button variant="contained" color="primary" type="submit" id="SubmitButton">
                            Log In
                        </Button>
                    </Grid>
                </Grid>
            </form>
        </div>
    )
}

export default FormLogIn;