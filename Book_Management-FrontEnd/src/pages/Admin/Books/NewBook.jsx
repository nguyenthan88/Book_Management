import '../Scss/New.scss';
import Button from '@mui/material/Button';

import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

function NewBook({ title }) {
    const [books, setBook] = useState([]);
    const [bookName, setBookName] = useState([]);
    const [publishingYear, setPublishingYear] = useState([]);
    const [price, setPrice] = useState([]);
    const [description, setDescription] = useState([]);
    const [categoryId, setCategoryId] = useState([]);
    const [addResult, setAddResult] = useState(false);

    const history = useNavigate();

    function handleClick(e) {
        e.preventDefault();
        history('/book');
    }

    const addCategory = async () => {
        if (bookName != null) {
            try {
                const response = await fetch(`https://localhost:7233/Book`, {
                    method: 'POST',
                    body: JSON.stringify({
                        bookName: bookName,
                        publishingYear: publishingYear,
                        price: price,
                        description: description,
                        categoryId: categoryId,
                    }),
                    headers: {
                        Accept: 'application/json',
                        'Content-Type': 'application/json',
                        'Access-Control-Allow-Origin': '*',
                    },
                });

                const data = response.json();

                if (data != null) {
                    setAddResult((pre) => !pre);
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
        <div className="news">
            <div className="new">
                <div className="newContainer">
                    <div className="top">
                        <h1>{title}</h1>
                    </div>
                    <div className="bottom">
                        <div className="right">
                            <form>
                                <div className="formInput">
                                    <input hidden value={books.BookId} />
                                    <label>Book Name</label>
                                    <input value={bookName} onChange={(e) => setBookName(e.target.value)} />
                                    <label>Publishing Year</label>
                                    <input value={publishingYear} onChange={(e) => setPublishingYear(e.target.value)} />
                                    <label>Description</label>
                                    <input value={description} onChange={(e) => setDescription(e.target.value)} />
                                    <label>Price</label>
                                    <input value={price} onChange={(e) => setPrice(e.target.value)} />
                                    <label>Category Id</label>
                                    <input value={categoryId} onChange={(e) => setCategoryId(e.target.value)} />
                                </div>

                                <Button
                                    className="btn"
                                    style={{ margin: '10px', marginLeft: '70px' }}
                                    type="submit"
                                    variant="outlined"
                                    color="success"
                                    onClick={addCategory}
                                >
                                    Submit
                                </Button>
                                <Button
                                    className="btn"
                                    style={{ margin: '10px', marginLeft: '70px' }}
                                    type="submit"
                                    variant="outlined"
                                    color="primary"
                                    onClick={handleClick}
                                >
                                    Back To Book
                                </Button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default NewBook;
