import { Box, Button, Grid, Tab, Tabs, TextField, Typography } from "@mui/material";
import React from "react";
import { useCookies } from "react-cookie";
import CreateOffer from "./CreateOffer";
import LoginComponent from "./LoginComponent";
import Offer from "./Offer";
import SearchOffer from "./SearchOffer";
import { useAsync } from "react-async"
import SettingsComponent from "./SettingsComponent";
import BrowseOffers from "./BrowseOffers";

const Index = () =>
{
    interface TabPanelProps 
    {
        children?: React.ReactNode;
        index: number;
        value: number;
    }
    
    const [value, setValue] = React.useState(0);

    function TabPanel(props: TabPanelProps) 
    {
    const { children, value, index, ...other } = props;
    
    return (
        <div
          role="tabpanel"
          hidden={value !== index}
          id={`simple-tabpanel-${index}`}
          aria-labelledby={`simple-tab-${index}`}
          {...other}
        >
          {value === index && (
            <Box sx={{ p: 3 }}>
              <Typography>{children}</Typography>
            </Box>
          )}
        </div>
      );
    }
    
    function a11yProps(index: number) {
        return {
          id: `simple-tab-${index}`,
          'aria-controls': `simple-tabpanel-${index}`,
        };
    }

    const handleChange = (event: React.SyntheticEvent, newValue: number) => {
        setValue(newValue);
      };

    const [cookiesT, setCookieT, removeCookieT] = useCookies(['token']);
    const [cookiesU, setCookieU, removeCookieU] = useCookies(['id']);

    var TabIndex = "Null"

    var ThirdIndexTab

    if (cookiesT.token == null)
    {
      TabIndex = "Sign up/Log in"
      ThirdIndexTab = <LoginComponent/>
    }
    else
    {
      TabIndex = "My Account"
      ThirdIndexTab = <SettingsComponent/>
    }
      
    return (
        <div>
            <Grid container>
                <Grid item xs={12}>
                  <Tabs value={value} onChange={handleChange} variant="scrollable" scrollButtons allowScrollButtonsMobile>
                  <Tab label="Search" {...a11yProps(0)} />
                    <Tab label="Browse Offers" {...a11yProps(1)} />
                    <Tab label="Create Offer" {...a11yProps(2)} />
                    <Tab label={TabIndex} {...a11yProps(3)} />
                  </Tabs>
                </Grid>
                <Grid item xs={12}>
                  <TabPanel value={value} index={0}>
                    <SearchOffer/>
                  </TabPanel>
                  <TabPanel value={value} index={1}>
                    <Grid container>
                      <Grid item xs={0} md={2}></Grid>
                      <Grid item xs={0} md={8}>
                        {/* <BrowseOffers/> */}
                        <Offer 
                          title={"I am selling a C63s Coupee 2015"} 
                          brand={"Mercedes"} 
                          extra={"HUD, Heated seats, Ventilated seats, Panorama roof, etc."} 
                          engine={"4.0L V8 Bi-Turbo"}
                          location={"Hamburg, Germany"} 
                          price={"49,999.00 EUR"} 
                          model={"C63s"} 
                          srcimg={"https://editorials.autotrader.ca/media/189449/2020-mercedes-amg-c-63-s-coupe-02-dw.jpg?anchor=center&mode=crop&width=1920&height=1080&rnd=132506729798800000"}/>
                      
                      <Offer 
                          title={"I am selling a C63s Coupee 2015"} 
                          brand={"Mercedes"} 
                          extra={"HUD, Heated seats, Ventilated seats, Panorama roof, etc."} 
                          engine={"4.0L V8 Bi-Turbo"}
                          location={"Hamburg, Germany"} 
                          price={"49,999.00 EUR"} 
                          model={"C63s"} 
                          srcimg={"https://editorials.autotrader.ca/media/189449/2020-mercedes-amg-c-63-s-coupe-02-dw.jpg?anchor=center&mode=crop&width=1920&height=1080&rnd=132506729798800000"}/>

<Offer 
                          title={"I am selling a C63s Coupee 2015"} 
                          brand={"Mercedes"} 
                          extra={"HUD, Heated seats, Ventilated seats, Panorama roof, etc."} 
                          engine={"4.0L V8 Bi-Turbo"}
                          location={"Hamburg, Germany"} 
                          price={"49,999.00 EUR"} 
                          model={"C63s"} 
                          srcimg={"https://editorials.autotrader.ca/media/189449/2020-mercedes-amg-c-63-s-coupe-02-dw.jpg?anchor=center&mode=crop&width=1920&height=1080&rnd=132506729798800000"}/>

<Offer 
                          title={"I am selling a C63s Coupee 2015"} 
                          brand={"Mercedes"} 
                          extra={"HUD, Heated seats, Ventilated seats, Panorama roof, etc."} 
                          engine={"4.0L V8 Bi-Turbo"}
                          location={"Hamburg, Germany"} 
                          price={"49,999.00 EUR"} 
                          model={"C63s"} 
                          srcimg={"https://editorials.autotrader.ca/media/189449/2020-mercedes-amg-c-63-s-coupe-02-dw.jpg?anchor=center&mode=crop&width=1920&height=1080&rnd=132506729798800000"}/>

<Offer 
                          title={"I am selling a C63s Coupee 2015"} 
                          brand={"Mercedes"} 
                          extra={"HUD, Heated seats, Ventilated seats, Panorama roof, etc."} 
                          engine={"4.0L V8 Bi-Turbo"}
                          location={"Hamburg, Germany"} 
                          price={"49,999.00 EUR"} 
                          model={"C63s"} 
                          srcimg={"https://editorials.autotrader.ca/media/189449/2020-mercedes-amg-c-63-s-coupe-02-dw.jpg?anchor=center&mode=crop&width=1920&height=1080&rnd=132506729798800000"}/>

<Offer 
                          title={"I am selling a C63s Coupee 2015"} 
                          brand={"Mercedes"} 
                          extra={"HUD, Heated seats, Ventilated seats, Panorama roof, etc."} 
                          engine={"4.0L V8 Bi-Turbo"}
                          location={"Hamburg, Germany"} 
                          price={"49,999.00 EUR"} 
                          model={"C63s"} 
                          srcimg={"https://editorials.autotrader.ca/media/189449/2020-mercedes-amg-c-63-s-coupe-02-dw.jpg?anchor=center&mode=crop&width=1920&height=1080&rnd=132506729798800000"}/>

<Offer 
                          title={"I am selling a C63s Coupee 2015"} 
                          brand={"Mercedes"} 
                          extra={"HUD, Heated seats, Ventilated seats, Panorama roof, etc."} 
                          engine={"4.0L V8 Bi-Turbo"}
                          location={"Hamburg, Germany"} 
                          price={"49,999.00 EUR"} 
                          model={"C63s"} 
                          srcimg={"https://editorials.autotrader.ca/media/189449/2020-mercedes-amg-c-63-s-coupe-02-dw.jpg?anchor=center&mode=crop&width=1920&height=1080&rnd=132506729798800000"}/>
                      </Grid>
                      <Grid item xs={0} md={2}></Grid>
                    </Grid>
                  </TabPanel>
                  <TabPanel value={value} index={2}>
                    <CreateOffer/>
                  </TabPanel>
                  <TabPanel value={value} index={3}>
                    {ThirdIndexTab}
                  </TabPanel>
                </Grid>
            </Grid>
        </div>
    )
}

export default Index