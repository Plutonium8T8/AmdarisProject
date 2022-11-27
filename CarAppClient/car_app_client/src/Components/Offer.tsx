import { Box, Button, Grid, Tab, Tabs, TextField, Typography } from "@mui/material";
import React from "react";

const Offer = () =>
{
    return (
        <Box>
            <Grid container id="OfferGrid">
                <Grid item xs={12} sm={8} className="fill">
                    <img src="https://www.cnet.com/a/img/resize/f5c9f9a4c5f0582568394887195e10c171c8b7d8/hub/2020/10/22/9d78c515-47ef-4fed-9122-c534a7ca8890/2020-mercedes-amg-c63-s-coupe-65.jpg?auto=webp&width=1200">
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
                                Title: Selling 2015 C63s Mercedes
                            </Grid>
                            <Grid item xs={12}>
                                Car Brand: Mercedes
                            </Grid>
                            <Grid item xs={12}>
                                Car Model: C63s
                            </Grid>
                            <Grid item xs={12}>
                                Price: 50,000.00 usd
                            </Grid>
                            <Grid item xs={12}>
                                Location: Hamburg, Germany, H3121
                            </Grid>
                            <Grid item xs={12}>
                                Engine: 4.0L Twin-Turbo V8
                            </Grid>
                            <Grid item xs={12}>
                                Extra: HUD, Heated Seats, etc.
                            </Grid>
                        </Grid>
                    </Box>
                </Grid>
            </Grid>
        </Box>
    )
}

export default Offer