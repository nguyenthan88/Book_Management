import '../Scss/Edit.scss';
import Button from '@mui/material/Button';

import { Box, Grid, TextField } from '@mui/material';
import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import axios from 'axios';

function EditBook({ title }) {
    const [book, setBook] = useState({
        bookId: '',
        bookName: '',
        publishingYear: '',
        price: '',
        description: '',
        categoryId: '',
    });

    const history = useNavigate();
    const { bookId } = useParams();

    function handleClick(e) {
        e.preventDefault();
        history('/book');
    }

    useEffect(() => {
        async function getBook() {
            try {
                const book = await axios.get(`https://localhost:7233/Book/${bookId}`);
                console.log(book.data);
                setBook(book.data);
            } catch (error) {
                console.log('Something is Wrong');
            }
        }
        getBook();
    }, [bookId]);

    function handleChange(e) {
        setBook({
            ...book,
            [e.target.name]: e.target.value,
        });
    }

    async function handleEdit(e) {
        e.preventDefault();
        try {
            await axios.put(`https://localhost:7233/Book/${bookId}`, book);
            history('/book');
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
                                            value={bookId}
                                            disabled
                                        />
                                    </Grid>
                                    <Grid item xs={12}>
                                        <TextField
                                            autoComplete="bookName"
                                            name="bookName"
                                            variant="outlined"
                                            required
                                            fullWidth
                                            id="bookName"
                                            label="Name"
                                            value={book.bookName}
                                            onChange={(e) => handleChange(e)}
                                        />
                                    </Grid>

                                    <Grid item xs={12}>
                                        <TextField
                                            autoComplete="publishingYear"
                                            name="publishingYear"
                                            variant="outlined"
                                            required
                                            fullWidth
                                            type={`datetime`}
                                            id="publishingYear"
                                            label="Publishing Year"
                                            value={book.publishingYear}
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
                                            value={book.description}
                                            onChange={(e) => handleChange(e)}
                                        />
                                    </Grid>
                                    <Grid item xs={12}>
                                        <TextField
                                            autoComplete="price"
                                            name="price"
                                            variant="outlined"
                                            required
                                            fullWidth
                                            id="price"
                                            label="Price"
                                            value={book.price}
                                            onChange={(e) => handleChange(e)}
                                        />
                                    </Grid>
                                    <Grid item xs={12}>
                                        <TextField
                                            autoComplete="categoryId"
                                            name="categoryId"
                                            variant="outlined"
                                            required
                                            fullWidth
                                            id="categoryId"
                                            label="Category Id"
                                            value={book.categoryId}
                                            // disabled
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
}

export default EditBook;
