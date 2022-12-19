import * as React from 'react';
import moment from 'moment';
import { useEffect, useState } from 'react';
import { Outlet, Link } from 'react-router-dom';
import axios from 'axios';
import '../Scss/Books.scss';

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
import Pagination from '@mui/material/Pagination';
// import usePagination from '../Paging/Pagination';
import Stack from '@mui/material/Stack';
import Navbar from '../../../components/Navbar/Navbar';

const Search = styled('div')(({ theme }) => ({
    position: 'relative',
    height: '40px',
    margin: '10px',
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

function Books() {
    const [books, setBook] = useState([]);

    const [search, setSearch] = useState('');

    const [open, setOpen] = useState(false);

    const [addResult, setAddResult] = useState(false);

    const [activeBookId, setActiveBookId] = useState();

    const [pageCount, setpageCount] = useState(0);

    let limit = 5;

    useEffect(() => {
        const getComments = async () => {
            const res = await fetch(`https://localhost:7233/Book?PageNumber=1&PageSize=${limit}`);
            console.log(res);
            const data = await res.json();
            const total = res.headers.get('x-total-count');
            setpageCount(Math.ceil(total / limit));
            console.log(Math.ceil(total / 12));
            setBook(data);
        };

        getComments();
    }, [limit]);

    const fetchComments = async (currentPage) => {
        const res = await fetch(`https://localhost:7233/Book?PageNumber=${currentPage}&PageSize=${limit}`);
        console.log(res);
        const data = await res.json();
        return data;
    };

    const handlePageClick = async (data) => {
        console.log(data.selected);

        let currentPage = data.selected + 1;

        const commentsFormServer = await fetchComments(currentPage);

        setBook(commentsFormServer);
    };

    const handleClickOpen = (id) => {
        setActiveBookId(id);
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };
    const handleDelete = async (id) => {
        if (id != null) {
            try {
                const response = await fetch(`https://localhost:7233/Book/${id}`, {
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
            .get(`https://localhost:7233/Book`)
            .then((books) => {
                console.log(books.data);
                setBook(books.data);
            })

            .catch(() => {
                console.log('error');
            });
    }, [addResult]);

    return (
        <div>
            <Navbar />
            <div className="book">
                <div style={{ height: 1000, width: '100%' }}>
                    <div style={{ padding: '10px', display: 'flex' }}>
                        <Search>
                            <SearchIconWrapper>
                                <SearchIcon />
                            </SearchIconWrapper>
                            <StyledInputBase
                                placeholder="Search…"
                                inputProps={{ 'aria-label': 'search' }}
                                onChange={(e) => setSearch(e.target.value)}
                            />
                        </Search>
                    </div>
                    <Link to="/book/new" className="link" style={{ listStyle: 'none', textDecoration: 'none' }}>
                        <Button
                            style={{ marginTop: '15px', marginBottom: '15px' }}
                            type="submit"
                            variant="outlined"
                            color="success"
                        >
                            Add Book
                        </Button>
                    </Link>
                    <TableContainer component={Paper} className="table bottom title">
                        <Table sx={{ minWidth: 650 }} aria-label="simple table">
                            <TableHead>
                                <TableRow>
                                    <TableCell className="tableCell">ID</TableCell>
                                    <TableCell className="tableCell">Name</TableCell>
                                    <TableCell className="tableCell">PublishingYear</TableCell>
                                    <TableCell className="tableCell">Description</TableCell>
                                    <TableCell className="tableCell">Price</TableCell>
                                    <TableCell className="tableCell">Category ID</TableCell>
                                    <TableCell className="tableCell">Actions</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {books.length > 0
                                    ? books
                                          .filter((book) => {
                                              return search.toLowerCase() === ''
                                                  ? book
                                                  : book.bookName.toLowerCase().includes(search);
                                          })

                                          .map((book) => (
                                              <TableRow key={book.bookId}>
                                                  <TableCell className="tableCell">{book.bookId}</TableCell>
                                                  <TableCell className="tableCell">{book.bookName}</TableCell>
                                                  <TableCell className="tableCell">
                                                      {moment(book.publishingYear).format('DD/MM/YYYY')}
                                                  </TableCell>
                                                  <TableCell className="tableCell">{book.description}</TableCell>
                                                  <TableCell className="tableCell">{book.price}</TableCell>
                                                  <TableCell
                                                      className="tableCell"
                                                      style={{
                                                          paddingLeft: '50px',
                                                      }}
                                                  >
                                                      {book.categoryId}
                                                  </TableCell>
                                                  <TableCell className="tableCell">
                                                      <Link
                                                          to={`/book/viewbook/${book.bookId}`}
                                                          className="link"
                                                          style={{ listStyle: 'none', textDecoration: 'none' }}
                                                      >
                                                          <Button
                                                              style={{ marginTop: '15px', margin: '15px' }}
                                                              type="submit"
                                                              variant="outlined"
                                                              color="primary"
                                                          >
                                                              Details
                                                          </Button>
                                                      </Link>
                                                      <Link
                                                          to={`/book/editbook/${book.bookId}`}
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
                                                          onClick={() => handleClickOpen(book.bookId)}
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
                    <Stack spacing={2}>
                        <Pagination
                            count={pageCount}
                            page={pageCount}
                            variant="outlined"
                            shape="rounded"
                            onChange={handlePageClick}
                        />
                    </Stack>
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
                            <Button autoFocus color="error" onClick={() => handleDelete(activeBookId)}>
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

export default Books;
