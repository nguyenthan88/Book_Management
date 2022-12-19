import * as React from 'react';
import { useEffect, useState } from 'react';
import { Outlet, Link } from 'react-router-dom';
import axios from 'axios';
import '../Scss/Categories.scss';

import { styled, alpha } from '@mui/material/styles';
import Button from '@mui/material/Button';
import SearchIcon from '@mui/icons-material/Search';
import InputBase from '@mui/material/InputBase';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import Navbar from '../../../components/Navbar/Navbar';
// import Pagination from '@mui/material/Pagination';
// import Stack from '@mui/material/Stack';

const Search = styled('div')(({ theme }) => ({
    position: 'relative',
    height: '40px',
    marginBottom: '15px',
    borderRadius: theme.shape.borderRadius,
    backgroundColor: '#D3D3D3',
    '&:hover': {
        backgroundColor: alpha(theme.palette.common.black, 0.25),
    },
    marginLeft: -10,
    width: '100%',
    [theme.breakpoints.up('sm')]: {
        display: 'flex',
        width: '500px',
    },
}));

const SearchIconWrapper = styled('div')(({ theme }) => ({
    padding: theme.spacing(0, 2),
    height: '100%',
    position: 'absolute',
    pointerEvents: 'none',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
}));

const StyledInputBase = styled(InputBase)(({ theme }) => ({
    color: 'inherit',
    '& .MuiInputBase-input': {
        padding: theme.spacing(1, 1, 1, 0),
        // vertical padding + font size from searchIcon
        paddingLeft: `calc(1em + ${theme.spacing(4)})`,
        transition: theme.transitions.create('width'),
        width: '500px',
        [theme.breakpoints.up('sm')]: {
            width: '444px',
            '&:focus': {
                width: '444px',
            },
        },
    },
}));

function Categories() {
    const [categories, setCategories] = useState([]);

    const [search, setSearch] = useState('');

    const [open, setOpen] = useState(false);

    const [addResult, setAddResult] = useState(false);

    const [activeCategoryId, setActiveCategoryId] = useState();

    // const PER_PAGE = 5;
    // const count = Math.ceil(categories.length / PER_PAGE);

    const handleClickOpen = (id) => {
        setActiveCategoryId(id);
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    // const [page, setPage] = useState(1);
    // const loadPosts = async () => {
    //     const res = await axios.get(`https://localhost:7233/Category?PageNumber=${page}&PageSize=${PER_PAGE}`);
    //     setCategories(res.data);
    // };
    // useEffect(() => {
    //     loadPosts();
    // }, [page]);

    const handleDelete = async (id) => {
        if (id != null) {
            try {
                const response = await fetch(`https://localhost:7233/Category/${id}`, {
                    method: 'DELETE',
                    headers: {
                        Accept: 'application/json',
                        'Content-Type': 'application/json',
                        'Access-Control-Allow-Origin': '*',
                    },
                });

                const data = response.json();

                if (data != null) {
                    setAddResult((pre) => !pre);
                    handleClose();
                }
            } catch (error) {
                console.log('error');
            }
        }

        return null;
    };

    useEffect(() => {
        axios
            .get(`https://localhost:7233/Category`)
            .then((categories) => {
                console.log(categories.data);
                setCategories(categories.data);
            })

            .catch(() => {
                console.log('error');
            });
    }, [addResult]);

    return (
        <div>
            <Navbar />
            <div className="category">
                <div style={{ height: 1000, width: '100%' }}>
                    <div style={{ padding: '10px', display: 'flex' }}>
                        <Search>
                            <SearchIconWrapper>
                                <SearchIcon />
                            </SearchIconWrapper>
                            <StyledInputBase
                                value={search}
                                placeholder="Search…"
                                inputProps={{ 'aria-label': 'search' }}
                                onChange={(e) => setSearch(e.target.value)}
                            />
                        </Search>
                    </div>
                    <Link to="/category/new" className="link" style={{ listStyle: 'none', textDecoration: 'none' }}>
                        <Button
                            style={{ marginTop: '15px', marginBottom: '15px' }}
                            type="submit"
                            variant="outlined"
                            color="success"
                        >
                            Add Category
                        </Button>
                    </Link>

                    <TableContainer component={Paper} className="table bottom title">
                        <Table sx={{ minWidth: 450 }} aria-label="simple table">
                            <TableHead>
                                <TableRow>
                                    <TableCell className="tableCell">ID</TableCell>
                                    <TableCell className="tableCell">Category Name</TableCell>
                                    <TableCell className="tableCell">Description</TableCell>
                                    <TableCell className="tableCell">Actions</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {categories.length > 0
                                    ? categories
                                          .filter((category) => {
                                              return search.toLocaleLowerCase() === ''
                                                  ? category
                                                  : category.categoryName.toLocaleLowerCase().includes(search);
                                          })
                                          .map((category) => (
                                              <TableRow key={category.categoryId}>
                                                  <TableCell className="tableCell">{category.categoryId}</TableCell>
                                                  <TableCell className="tableCell">{category.categoryName}</TableCell>
                                                  <TableCell className="tableCell">{category.description}</TableCell>
                                                  <TableCell className="tableCell">
                                                      <Link
                                                          to={`/category/viewcategory/${category.categoryId}`}
                                                          className="link"
                                                          style={{ listStyle: 'none', textDecoration: 'none' }}
                                                      >
                                                          <Button
                                                              style={{ marginTop: '15px', margin: '15px' }}
                                                              type="submit"
                                                              variant="outlined"
                                                              color="secondary"
                                                          >
                                                              Details
                                                          </Button>
                                                      </Link>
                                                      <Link
                                                          to={`/category/editcategory/${category.categoryId}`}
                                                          className="link"
                                                          style={{ listStyle: 'none', textDecoration: 'none' }}
                                                      >
                                                          <Button
                                                              style={{ marginTop: '15px', margin: '15px' }}
                                                              type="submit"
                                                              variant="outlined"
                                                              color="secondary"
                                                          >
                                                              Edit
                                                          </Button>
                                                      </Link>
                                                      <Button
                                                          onClick={() => handleClickOpen(category.categoryId)}
                                                          style={{ marginTop: '15px', margin: '15px' }}
                                                          type="submit"
                                                          variant="outlined"
                                                          color="error"
                                                      >
                                                          Delete
                                                      </Button>
                                                  </TableCell>
                                              </TableRow>
                                          ))
                                    : null}
                            </TableBody>
                        </Table>
                    </TableContainer>
                    {/* <Stack spacing={2}>
                        <Pagination
                            count={count}
                            page={page}
                            variant="outlined"
                            shape="rounded"
                            onChange={(e, value) => setPage(value)}
                        />
                    </Stack> */}
                </div>
                <div>
                    <Dialog
                        open={open}
                        onClose={handleClose}
                        aria-labelledby="alert-dialog-title"
                        aria-describedby="alert-dialog-description"
                    >
                        <DialogTitle id="alert-dialog-title">{'Are you Delete?'}</DialogTitle>
                        <DialogContent>
                            <DialogContentText id="alert-dialog-description">
                                Let Google help apps determine location. This means sending anonymous location data to
                                Google, even when no apps are running.
                            </DialogContentText>
                        </DialogContent>
                        <DialogActions>
                            <Button onClick={handleClose}>Close</Button>
                            <Button autoFocus color="error" onClick={() => handleDelete(activeCategoryId)}>
                                Delete
                            </Button>
                        </DialogActions>
                    </Dialog>
                </div>
                <Outlet />
            </div>
        </div>
    );
}

export default Categories;
