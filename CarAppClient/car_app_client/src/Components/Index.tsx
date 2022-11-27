import { Box, Button, Grid, Tab, Tabs, TextField, Typography } from "@mui/material";
import React from "react";
import { useCookies } from "react-cookie";
import LoginComponent from "./LoginComponent";

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

    const [cookies, setCookie, removeCookie] = useCookies(['token']);

    var TabIndex = "Null"

    if (cookies.token == null)
    {
      TabIndex = "Sign up/Log in"
      const ThirdIndexTab = <LoginComponent/>
    }
    else
    {
      TabIndex = "My Account"
    }
      
    return (
        <div>
            <Grid container>
                <Grid item xs={12}>
                    <Tabs value={value} onChange={handleChange} centered>
                        <Tab label="Browse Offers" {...a11yProps(0)} />
                        <Tab label="Create Offer" {...a11yProps(1)} />
                        <Tab label={TabIndex} {...a11yProps(2)} />
                    </Tabs>
                </Grid>
                <Grid item xs={12}>
                    <TabPanel value={value} index={0}>

                    </TabPanel>
                    <TabPanel value={value} index={1}>

                    </TabPanel>
                    <TabPanel value={value} index={2}>
                      <LoginComponent/>
                    </TabPanel>
                </Grid>
            </Grid>
        </div>
    )
}

export default Index