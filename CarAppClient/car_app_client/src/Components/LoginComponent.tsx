import React from 'react';
import '../App.css';
import { Grid, Tabs, Tab, Typography, Box } from '@mui/material';
import '../Components/FormSignUp'
import FormSignUp from '../Components/FormSignUp';
import FormLogIn from '../Components/FormLogIn';

const LoginComponent = () =>
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

    return (
        <div>
            <Grid id='LoginGridContainer' container>
                <Grid className='LoginGrid' item xs={2}></Grid>

                <Grid className='LoginGrid' item xs={8}>
                    <Grid container>
                        <Grid item xs={7}></Grid>
                        <Grid item xs={5} id='FormGrid'>
                            <Grid item xs={12}>
                                <Tabs value={value} onChange={handleChange} centered>
                                    <Tab label="Sign up" {...a11yProps(0)} />
                                    <Tab label="Log in" {...a11yProps(1)} />
                                </Tabs>
                            </Grid>
                            <Grid item xs={12}>
                                <TabPanel value={value} index={0}>
                                    <FormSignUp/>
                                </TabPanel>
                                <TabPanel value={value} index={1}>
                                    <FormLogIn/>
                                </TabPanel>
                            </Grid>
                        </Grid>
                    </Grid>
                </Grid>
                <Grid className='LoginGrid' item xs={2}></Grid>
            </Grid>
        </div>
    )
}

export default LoginComponent