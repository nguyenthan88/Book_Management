import React from 'react';

import { Grid, Paper, Avatar, TextField, Button, Link } from '@mui/material';
import AddCircleOutlineOutlinedIcon from '@mui/icons-material/AddCircleOutlineOutlined';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';

const Login = () => {
    const paperStyle = { padding: 40, height: '50vh', width: 280, margin: '70px auto' };
    const avatarStyle = { backgroundColor: '#1bbd7e' };
    const btnstyle = { margin: '20px 0' };

    // const [username, setUserName] = useState('');
    // const [password, setPassword] = useState('');

    // const history = useNavigate();

    // async function login() {
    //     let item = { username, password };
    //     let result = await fetch('https://localhost:7233/api/Login', {
    //         method: 'POST',
    //         headers: {
    //             'Content-Type': 'application/json',
    //             Accept: 'application/json',
    //         },
    //         body: JSON.stringify(item),
    //     });
    //     result = await result.json();
    //     localStorage.setItem(JSON.stringify(result));
    //     history('/home');
    // }

    return (
        <Grid>
            <Paper elevation={10} style={paperStyle}>
                <Grid align="center">
                    <Avatar style={avatarStyle}>
                        <AddCircleOutlineOutlinedIcon />
                    </Avatar>
                    <h2>Sign In</h2>
                </Grid>
                <TextField
                    style={{ margin: 5 }}
                    label="Username"
                    placeholder="Enter username"
                    fullWidth
                    required
                    // onChange={(e) => setUserName(e.target.value)}
                />
                <TextField
                    style={{ margin: 5 }}
                    label="Password"
                    placeholder="Enter password"
                    type="password"
                    fullWidth
                    required
                    // onChange={(e) => setPassword(e.target.value)}
                />
                <FormControlLabel
                    control={<Checkbox style={{ margin: 5 }} name="checkedB" color="primary" />}
                    label="Remember me"
                />
                <Button
                    // onClick={login}
                    type="submit"
                    color="primary"
                    variant="contained"
                    style={{ margin: 5, btnstyle }}
                    fullWidth
                >
                    <Link style={{ textDecoration: 'none', color: 'white' }} href="/home">
                        Login
                    </Link>
                </Button>
            </Paper>
        </Grid>
    );
};

export default Login;
