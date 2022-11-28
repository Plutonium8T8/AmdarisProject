import { Box, Button, Grid, TextField } from "@mui/material";
import { useState } from "react";
import { useCookies } from "react-cookie";
import * as yup from 'yup';

const defaultSettingsValues = {
    username: "",
    email: "",
    phone: "",
    password: "",
    confirm: "",
    id: ""
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

const SettingsComponent = () =>
{
    const [settingsValues, setFormValues] = useState(defaultSettingsValues);
    
    const [cookiesT, setCookieT, removeCookieT] = useCookies(['token']);
    const [cookiesU, setCookieU, removeCookieU] = useCookies(['id']);

    settingsValues.id = cookiesU.id

    const handleSubmit = async (event: { preventDefault: () => void; }) => {
        event.preventDefault();
        await schema.isValid(settingsValues)
        .then((valid) => 
        {
            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");
            myHeaders.append("Authorization", "Bearer " + cookiesT.token)

            var raw = JSON.stringify(settingsValues);

            var requestOptions : RequestInit = {
                method: 'PUT',
                headers: myHeaders,
                body: raw,
                redirect: 'follow'
              };
            
            fetch("http://127.0.0.1:5000/users", requestOptions)
            .then(response => response.text())
            .then(result => console.log(result))
            .catch(error => console.log('error', error));
        })
        .catch((err) => {
            console.log(err.name);
            console.log(err.errors);
        })
    };

    const handleLogout = async (event: { preventDefault: () => void; }) => {
        event.preventDefault();
        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        myHeaders.append("Authorization", "Bearer " + cookiesT.token)

        var raw = JSON.stringify({});

        var requestOptions : RequestInit = {
            method: 'POST',
            headers: myHeaders,
            body: raw,
            redirect: 'follow'
            };
        
        await fetch("http://127.0.0.1:5000/auth", requestOptions)
        .then(response => response.text())
        .then(result => console.log(result))
        .catch(error => console.log('error', error));

        removeCookieT("token")
        removeCookieU("id")
    };

    const handleDelete = async (event: { preventDefault: () => void; }) => {
        event.preventDefault();
        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        myHeaders.append("Authorization", "Bearer " + cookiesT.token)

        var raw = JSON.stringify({});

        var requestOptions : RequestInit = {
            method: 'DELETE',
            headers: myHeaders,
            body: raw,
            redirect: 'follow'
            };
        
        await fetch("http://127.0.0.1:5000/users/"+cookiesU.id, requestOptions)
        .then(response => response.text())
        .then(result => console.log(result))
        .catch(error => console.log('error', error));
    };

    const handleInputChange = (e: { target: { name: any; value: any; }; }) => {
        const { name, value } = e.target;
        setFormValues({
        ...settingsValues,
        [name]: value,
        });
    };    

    return(
        <Box>
            <form onSubmit={handleSubmit}>
                <Grid container className='FormGrid'>
                <Grid item xs={0} md={2}></Grid>
                    <Grid item xs={12} md={8} className="FormInputs">
                        <TextField className='FormTextField'
                            id="username-input"
                            name="username"
                            label="Username"
                            type="text"
                            value={settingsValues.username}
                            onChange={handleInputChange}
                            fullWidth
                        />
                    </Grid>
                    <Grid item xs={0} md={2}></Grid>
                    <Grid item xs={0} md={2}></Grid>
                    <Grid item xs={12} md={8} className="FormInputs">
                        <TextField className='FormTextField'
                            id="email-input"
                            name="email"
                            label="Email"
                            type="text"
                            value={settingsValues.email}
                            onChange={handleInputChange}
                            fullWidth
                        />
                    </Grid>
                    <Grid item xs={0} md={2}></Grid>
                    <Grid item xs={0} md={2}></Grid>
                    <Grid item xs={12} md={8} className="FormInputs">
                        <TextField className='FormTextField'
                            id="phone-input"
                            name="phone"
                            label="Phone number"
                            type="text"
                            value={settingsValues.phone}
                            onChange={handleInputChange}
                            fullWidth
                        />
                    </Grid>
                    <Grid item xs={0} md={2}></Grid>
                    <Grid item xs={0} md={2}></Grid>
                    <Grid item xs={12} md={8} className="FormInputs">
                        <TextField className='FormTextField'
                            id="outlined-password-input"
                            name="password"
                            label="Password"
                            type="password"
                            value={settingsValues.password}
                            onChange={handleInputChange}
                            fullWidth
                        />
                    </Grid>
                    <Grid item xs={0} md={2}></Grid>
                    <Grid item xs={0} md={2}></Grid>
                    <Grid item xs={12} md={8} className="FormInputs">
                        <TextField className='FormTextField'
                            id="confirm-input"
                            name="confirm"
                            label="Confirm"
                            type="password"
                            value={settingsValues.confirm}
                            onChange={handleInputChange}
                            fullWidth
                        />
                    </Grid>
                    <Grid item xs={0} md={2}></Grid>
                    <Grid item xs={0} md={3}></Grid>
                    <Grid item  xs={12} md={2}>
                        <Button variant="contained" color="primary" type="submit" id="SettingsButton">
                            Change account settings
                        </Button>
                    </Grid>
                    <Grid item  xs={12} md={2}>
                        <Button variant="contained" color="primary"onClick={handleLogout} id="LogoutButton">
                            Log out
                        </Button>
                    </Grid>
                    <Grid item  xs={12} md={2}>
                        <Button variant="contained" color="primary" onClick={handleDelete} id="DeleteButton">
                            Delete account
                        </Button>
                    </Grid>
                    <Grid item xs={0} md={3}></Grid>
                </Grid>
            </form>
        </Box>
    )
}

export default SettingsComponent;