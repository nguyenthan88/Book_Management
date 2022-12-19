import React from 'react';
import { Grid, Paper, Avatar, Typography, TextField, Button } from '@mui/material';
import AddCircleOutlineOutlinedIcon from '@mui/icons-material/AddCircleOutlineOutlined';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
const Signup = () => {
    const paperStyle = { padding: '30px 20px', width: 300, margin: '20px auto' };
    const headerStyle = { margin: 0 };
    const avatarStyle = { backgroundColor: '#1bbd7e' };
    return (
        <Grid>
            <Paper elevation={20} style={paperStyle}>
                <Grid align="center">
                    <Avatar style={avatarStyle}>
                        <AddCircleOutlineOutlinedIcon />
                    </Avatar>
                    <h2 style={headerStyle}>Sign Up</h2>
                    <Typography variant="caption" gutterBottom>
                        Please fill this form to create an account !
                    </Typography>
                </Grid>
                <form>
                    <TextField style={{ margin: 5 }} fullWidth label="Name" placeholder="Enter your name" />
                    <TextField style={{ margin: 5 }} fullWidth label="Email" placeholder="Enter your email" />
                    <TextField
                        style={{ margin: 5 }}
                        fullWidth
                        label="Phone Number"
                        placeholder="Enter your phone number"
                    />
                    <TextField style={{ margin: 5 }} fullWidth label="Password" placeholder="Enter your password" />
                    <TextField
                        style={{ margin: 5 }}
                        fullWidth
                        label="Confirm Password"
                        placeholder="Confirm your password"
                    />
                    <FormControlLabel
                        style={{ margin: 5 }}
                        control={<Checkbox name="checkedA" />}
                        label="I accept the terms and conditions."
                    />
                    <Button style={{ margin: 5 }} type="submit" variant="contained" color="primary">
                        Sign up
                    </Button>
                </form>
            </Paper>
        </Grid>
    );
};

export default Signup;
