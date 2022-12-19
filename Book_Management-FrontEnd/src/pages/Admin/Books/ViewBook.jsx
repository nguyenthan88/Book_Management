import {
    Typography,
    Box,
    TableContainer,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow,
    Paper,
    Button,
} from '@mui/material';

import moment from 'moment';
import { useParams, useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import axios from 'axios';
import '../Scss/View.scss';

const ViewBook = ({ title }) => {
    const { bookId } = useParams();
    const [book, setBook] = useState([]);
    const history = useNavigate();

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

    function handleClick() {
        history('/book');
    }
    return (
        <div className="views">
            <div style={{ height: 1000, width: '100%' }}>
                <Box textAlign="center" p={2}>
                    <Typography variant="h4">{title}</Typography>
                </Box>
                <TableContainer component={Paper} className="table bottom title">
                    <Table>
                        <TableHead>
                            <TableRow style={{ backgroundColor: 'white' }}>
                                <TableCell align="center">ID</TableCell>
                                <TableCell align="center">Name</TableCell>
                                <TableCell align="center">PublishingYear</TableCell>
                                <TableCell align="center">Description</TableCell>
                                <TableCell align="center">Price</TableCell>
                                <TableCell align="center">Category Id</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            <TableRow>
                                <TableCell align="center">{book.bookId}</TableCell>
                                <TableCell align="center">{book.bookName}</TableCell>
                                <TableCell align="center">{moment(book.publishingYear).format('DD/MM/YYYY')}</TableCell>
                                <TableCell align="center">{book.description}</TableCell>
                                <TableCell align="center">{book.price}</TableCell>
                                <TableCell align="center">{book.categoryId}</TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>
                <Box m={3} textAlign="center">
                    <Button variant="outlined" color="primary" onClick={handleClick}>
                        Back to Book
                    </Button>
                </Box>
            </div>
        </div>
    );
};

export default ViewBook;
