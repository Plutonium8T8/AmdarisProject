import { Button, Grid, TextField } from "@mui/material";
import { useState } from "react";
import * as yup from 'yup';

const defaultValues = {
    username: "",
    email: "",
    phone: "",
    password: "",
    repeat_password: ""
};

const schema = yup.object(
    {
        username : yup.string().required('Login is required'),
        password : yup.string().required('Login is required').min(8, 'Password must be longer than 8.').max(20, 'Password must be shorter than 20.'),
    })

const FormLogIn = () =>
{
    const [formValues, setFormValues] = useState(defaultValues);
    
    const handleSubmit = async (event: { preventDefault: () => void; }) => {
        event.preventDefault();
        await schema.isValid(formValues)
        .then((valid) => 
        {
            console.log(valid)
        })
        .catch((err) => {
            console.log(err.name);
            console.log(err.errors);
        })
    };

    const handleInputChange = (e: { target: { name: any; value: any; }; }) => {
        const { name, value } = e.target;
        setFormValues({
        ...formValues,
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
                            value={formValues.username}
                            onChange={handleInputChange}
                        />
                    </Grid>
                    <Grid item xs={12} className="FormInputs">
                        <TextField className='FormTextField'
                            id="outlined-password-input"
                            name="password"
                            label="Password"
                            type="password"
                            value={formValues.password}
                            onChange={handleInputChange}
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