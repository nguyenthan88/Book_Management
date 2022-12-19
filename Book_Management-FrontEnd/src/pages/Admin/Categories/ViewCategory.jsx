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

import { useParams, useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import axios from 'axios';
import '../Scss/View.scss';

const ViewCategory = ({ title }) => {
    const { categoryId } = useParams();
    const [category, setCategory] = useState([]);
    const history = useNavigate();

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

    function handleClick() {
        history('/category');
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
                                <TableCell align="center">Description</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            <TableRow>
                                <TableCell align="center">{category.categoryId}</TableCell>
                                <TableCell align="center">{category.categoryName}</TableCell>
                                <TableCell align="center">{category.description}</TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>
                <Box m={3} textAlign="center">
                    <Button variant="outlined" color="primary" onClick={handleClick}>
                        Back to Category
                    </Button>
                </Box>
            </div>
        </div>
    );
};

export default ViewCategory;
