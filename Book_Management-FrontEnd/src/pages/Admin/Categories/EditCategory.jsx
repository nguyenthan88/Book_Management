import '../Scss/Edit.scss';
import Button from '@mui/material/Button';

import { Box, Grid, TextField } from '@mui/material';
import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import axios from 'axios';

const EditCategory = ({ title }) => {
    const [category, setCategory] = useState({
        categoryId: '',
        categoryName: '',
        description: '',
    });

    const history = useNavigate();
    const { categoryId } = useParams();

    function handleClick(e) {
        e.preventDefault();
        history('/category');
    }

    useEffect(() => {
        async function getCategory() {
            try {
                const category = await axios.get(`https://localhost:7233/Category/${categoryId}`);
                console.log(category.data);
                setCategory(category.data);
            } catch (error) {
                console.log('Something is Wrong');
            }
        }
        getCategory();
    }, [categoryId]);

    function handleChange(e) {
        setCategory({
            ...category,
            [e.target.name]: e.target.value,
        });
    }

    async function handleEdit(e) {
        e.preventDefault();
        try {
            await axios.put(`https://localhost:7233/Category/${categoryId}`, category);
            history('/category');
        } catch (error) {
            console.log('Something is Wrong');
        }
    }

    return (
        <div className="news">
            <div className="new">
                <div className="newContainer">
                    <div className="top">
                        <h1>{title}</h1>
                    </div>
                    <div className="bottom">
                        <div className="right">
                            <form>
                                <Grid container spacing={2}>
                                    <Grid item xs={12}>
                                        <TextField
                                            autoComplete="id"
                                            name="id"
                                            variant="outlined"
                                            required
                                            fullWidth
                                            id="id"
                                            label="ID"
                                            autoFocus
                                            value={categoryId}
                                            disabled
                                        />
                                    </Grid>
                                    <Grid item xs={12}>
                                        <TextField
                                            autoComplete="categoryName"
                                            name="categoryName"
                                            variant="outlined"
                                            required
                                            fullWidth
                                            id="categoryName"
                                            label="Name"
                                            value={category.categoryName}
                                            onChange={(e) => handleChange(e)}
                                        />
                                    </Grid>

                                    <Grid item xs={12}>
                                        <TextField
                                            autoComplete="description"
                                            name="description"
                                            variant="outlined"
                                            required
                                            fullWidth
                                            id="description"
                                            label="Description"
                                            value={category.description}
                                            onChange={(e) => handleChange(e)}
                                        />
                                    </Grid>
                                </Grid>
                                <Box m={3}>
                                    <Button
                                        xs={12}
                                        className="btn"
                                        style={{ margin: '10px', marginLeft: '70px' }}
                                        type="submit"
                                        variant="outlined"
                                        color="success"
                                        onClick={(e) => handleEdit(e)}
                                    >
                                        Update
                                    </Button>
                                    <Button
                                        xs={12}
                                        type="button"
                                        color="primary"
                                        className="btn"
                                        style={{ margin: '10px', marginLeft: '70px' }}
                                        variant="outlined"
                                        onClick={(e) => handleClick(e)}
                                    >
                                        Back
                                    </Button>
                                </Box>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default EditCategory;
