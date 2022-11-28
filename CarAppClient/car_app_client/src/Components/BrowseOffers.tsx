import { Box, Button, Grid, Tab, Tabs, TextField, Typography } from "@mui/material";
import React from "react";
import { useCookies } from "react-cookie";
import CreateOffer from "./CreateOffer";
import LoginComponent from "./LoginComponent";
import Offer from "./Offer";
import SearchOffer from "./SearchOffer";
import { useAsync } from "react-async"
import SettingsComponent from "./SettingsComponent";

const defaultOfferValues = {
    brand: "",
    model: "",
    engine: "",
    description: "",
    extra: ""
  }

const BrowseOffers = () => 
{
    const state = useAsync(
        async () =>
        {
            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");
  
            var raw = JSON.stringify(defaultOfferValues);
  
            var requestOptions : RequestInit = {
                method: 'POST',
                headers: myHeaders,
                body: raw,
                redirect: 'follow'
                };
  
            var element : JSX.Element[] = []
                
            const getOffersAsync = await fetch("http://127.0.0.1:5000/offers/search/0", requestOptions)
            .then(response => response.json())
            .then(result => 
                {
                    
                    if (result.byteLength == 0)
                    {
                        element = [<Box
                                component="div"
                                id='OfferBox'
                                sx={{
                                overflow: 'auto',
                                my: 2,
                                p: 1,
                                bgcolor: (theme) =>
                                    theme.palette.mode === 'dark' ? '#101010' : 'grey.100',
                                color: (theme) =>
                                    theme.palette.mode === 'dark' ? 'grey.300' : 'grey.800',
                                border: '1px solid',
                                borderColor: (theme) =>
                                    theme.palette.mode === 'dark' ? 'grey.800' : 'grey.300',
                                borderRadius: 2,
                                fontSize: '0.875rem',
                                fontWeight: '700'
                                }}
                            >
                                No offers found.
                            </Box>]
                    }
                    else
                    {
                        result.forEach((item: any) => {
                            element.push(
                                <Offer title={item.title} brand={item.brand} extra={item.extra} engine={item.engine}
                                location={item.location} price={item.price} model={item.model} srcimg={""}/>
                            )
                        });
                    }
                } 
            )
            .catch(error => console.log('error', error))
  
            console.log(element)
  
            return element
        }
    )

    return (
        <div>
            {state.isLoading
                ? <div>Loading...</div>
                : state.error
                ? <div>Error: {state.error.message}</div>
                : <div>Value: {state.value}</div>
            }
        </div>
    )
}

export default BrowseOffers