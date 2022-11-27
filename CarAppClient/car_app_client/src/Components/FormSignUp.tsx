import { Box, Button, Grid, TextField } from "@mui/material";
import { useState } from "react";
import * as yup from 'yup';

const defaultSigninValues = {
    username: "",
    email: "",
    phone: "",
    password: "",
    confirm: ""
};

const phoneRegExp = /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/

const schema = yup.object(
    {
        username : yup.string().required('Login is required'),
        email : yup.string().required('Email is required').email(),
        phone : yup.string().matches(phoneRegExp, 'Phone number is not valid'),
        password : yup.string().required('Login is required').min(8, 'Password must be longer than 8.').max(20, 'Password must be shorter than 20.'),
        confirm : yup.string().required('Login is required').oneOf([yup.ref('password'), null], 'Passwords must match')
    });

const FormSignUp = () =>
{
    const [signinValues, setFormValues] = useState(defaultSigninValues);
    
    const handleSubmit = async (event: { preventDefault: () => void; }) => {
        event.preventDefault();
        await schema.isValid(signinValues)
        .then((valid) => 
        {
            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");

            var raw = JSON.stringify(signinValues);

            var requestOptions : RequestInit = {
                method: 'POST',
                headers: myHeaders,
                body: raw,
                redirect: 'follow'
              };
            
            fetch("http://127.0.0.1:5000/auth/register", requestOptions)
            .then(response => response.text())
            .then(result => console.log(result))
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
        ...signinValues,
        [name]: value,
        });
    };    

    return(
        <Box>
            <form onSubmit={handleSubmit}>
                <Grid container className='FormGrid'>
                    <Grid item xs={12} className="FormInputs">
                        <TextField className='FormTextField'
                            id="username-input"
                            name="username"
                            label="Username"
                            type="text"
                            value={signinValues.username}
                            onChange={handleInputChange}
                        />
                    </Grid>
                    <Grid item xs={12} className="FormInputs">
                        <TextField className='FormTextField'
                            id="email-input"
                            name="email"
                            label="Email"
                            type="text"
                            value={signinValues.email}
                            onChange={handleInputChange}
                        />
                    </Grid>
                    <Grid item xs={12} className="FormInputs">
                        <TextField className='FormTextField'
                            id="phone-input"
                            name="phone"
                            label="Phone number"
                            type="text"
                            value={signinValues.phone}
                            onChange={handleInputChange}
                        />
                    </Grid>
                    <Grid item xs={12} className="FormInputs">
                        <TextField className='FormTextField'
                            id="outlined-password-input"
                            name="password"
                            label="Password"
                            type="password"
                            value={signinValues.password}
                            onChange={handleInputChange}
                        />
                    </Grid>
                    <Grid item xs={12} className="FormInputs">
                        <TextField className='FormTextField'
                            id="confirm-input"
                            name="confirm"
                            label="Confirm"
                            type="password"
                            value={signinValues.confirm}
                            onChange={handleInputChange}
                        />
                    </Grid>
                    <Grid item  xs={12}>
                        <Button variant="contained" color="primary" type="submit" id="SubmitButton">
                            Sign Up
                        </Button>
                    </Grid>
                </Grid>
            </form>
        </Box>
    )
}

export default FormSignUp;