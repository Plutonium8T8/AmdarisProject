import { Box, Button, Grid, Tab, Tabs, TextField, Typography } from "@mui/material";
import React from "react";

function Offer(props: { title: string, brand: string, extra: string, engine: string, location: string, price: string, model: string, srcimg: string})
{
    return (
        <div>
            <Grid container id="OfferGrid">
                <Grid item xs={12} sm={8} className="fill">
                    <img src={props.srcimg}>
                    </img>
                </Grid>
                <Grid item xs={12} sm={4}>
                    <Box
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
                        <Grid container>
                            <Grid item xs={12}>
                                Title: {props.title}
                            </Grid>
                            <Grid item xs={12}>
                                Car Brand: {props.brand}
                            </Grid>
                            <Grid item xs={12}>
                                Car Model: {props.model}
                            </Grid>
                            <Grid item xs={12}>
                                Price: {props.price}
                            </Grid>
                            <Grid item xs={12}>
                                Location: {props.location}
                            </Grid>
                            <Grid item xs={12}>
                                Engine: {props.engine}
                            </Grid>
                            <Grid item xs={12}>
                                Extra: {props.extra}
                            </Grid>
                        </Grid>
                    </Box>
                </Grid>
            </Grid>
        </div>
    )
}

export default Offer