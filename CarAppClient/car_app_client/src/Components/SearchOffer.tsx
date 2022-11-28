import { Box, Button, Grid, Tab, Tabs, TextareaAutosize, TextField, Typography } from "@mui/material";
import React, { useState } from "react";
import { useCookies } from "react-cookie";

const defaultOfferValues = {
    brand: "",
    model: "",
    engine: "",
    description: "",
    extra: "",
    userid: ""
}

const SearchOffer = () => 
{
    const [offerValues, setFormValues] = useState(defaultOfferValues);
    
    const [cookiesT, setCookieT, removeCookieT] = useCookies(['token']);
    const [cookiesU, setCookieU, removeCookieU] = useCookies(['id']);

    var id = cookiesU.id
    
    const handleSubmit = async (event: { preventDefault: () => void; }) => {
        event.preventDefault();

        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        myHeaders.append("Authorization", "Bearer " + cookiesT.token)

        offerValues.userid = id

        console.log(offerValues)

        var raw = JSON.stringify(offerValues);

        var requestOptions : RequestInit = {
            method: 'POST',
            headers: myHeaders,
            body: raw,
            redirect: 'follow'
            };
        
        fetch("http://127.0.0.1:5000/offers/search/0", requestOptions)
        .then(response => response.text())
        .then(result => console.log(result))
        .catch(error => console.log('error', error));
    }

    const handleInputChange = (e: { target: { name: any; value: any; }; }) => {
        const { name, value } = e.target;
        setFormValues({
        ...offerValues,
        [name]: value,
        });
    };    

    return(
        <Box>
            <Grid container id="SearchGrid">
                <Grid item xs={0} md={3}></Grid>
                <Grid item xs={12} md={6}>
                    <form onSubmit={handleSubmit}>
                        <Grid container className='FormGrid'>
                            <Grid item xs={3}></Grid>
                            <Grid item xs={12} className="FormInputs">
                                <TextField className='FormTextField'
                                    id="brand-input"
                                    name="brand"
                                    label="Car brand"
                                    type="text"
                                    value={offerValues.brand}
                                    onChange={handleInputChange}
                                    fullWidth
                                />
                            </Grid>
                            <Grid item xs={12} className="FormInputs">
                                <TextField className='FormTextField'
                                    id="model-input"
                                    name="model"
                                    label="Car model"
                                    type="text"
                                    value={offerValues.model}
                                    onChange={handleInputChange}
                                    fullWidth
                                />
                            </Grid>
                            <Grid item xs={12} className="FormInputs">
                                <TextField className='FormTextField'
                                    id="engine-input"
                                    name="engine"
                                    label="Engine"
                                    type="text"
                                    value={offerValues.engine}
                                    onChange={handleInputChange}
                                    fullWidth
                                />
                            </Grid>
                            <Grid item xs={12} className="FormInputs">
                                <TextField className='FormTextField'
                                    id="description-input"
                                    name="description"
                                    label="Description"
                                    type="text"
                                    value={offerValues.description}
                                    onChange={handleInputChange}
                                    multiline
                                    fullWidth
                                />
                            </Grid>
                            <Grid item xs={12} className="FormInputs">
                                <TextField className='FormTextField'
                                    id="extra-input"
                                    name="extra"
                                    label="Extra"
                                    type="text"
                                    value={offerValues.extra}
                                    onChange={handleInputChange}
                                    multiline
                                    fullWidth
                                />
                            </Grid>
                            <Grid item  xs={12}>
                                <Button variant="contained" color="primary" type="submit" id="SubmitButton">
                                    Search offer
                                </Button>
                            </Grid>
                            <Grid item xs={3}></Grid>
                        </Grid>
                    </form>                        
                </Grid>
                <Grid item xs={0} md={3}></Grid>
            </Grid>
        </Box>
    )
}

export default SearchOffer