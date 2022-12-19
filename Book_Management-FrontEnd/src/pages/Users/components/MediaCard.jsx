import * as React from 'react';
import { useEffect, useState, useContext } from 'react';
import axios from 'axios';
import './MediaCard.scss';

import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import BookContext from '../../../components/context/Context';

function BookLists({ title }) {
    const { addBook } = useContext(BookContext);

    const [books, setBook] = useState([]);
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
    }, []);

    return (
        <div className="card">
            <h1>{title}</h1>
            <div className="card-item">
                {books.map((item) => (
                    <Card key={item.bookId} sx={{ maxWidth: 450, margin: '10px' }}>
                        <CardMedia
                            component="img"
                            height="140"
                            image="https://static1.cbrimages.com/wordpress/wp-content/uploads/2022/09/naruto-looking-determined.jpg"
                            alt="green iguana"
                        />
                        <CardContent>
                            <Typography gutterBottom variant="h5" component="div">
                                {item.bookName}
                            </Typography>
                            <Typography variant="body2" color="text.secondary">
                                Description: {item.description}
                            </Typography>
                            <Typography variant="body2" color="text.secondary">
                                Price: {item.price}
                            </Typography>
                        </CardContent>
                        <CardActions>
                            <Button onClick={() => addBook(item)} size="small">
                                Add to List
                            </Button>
                        </CardActions>
                    </Card>
                ))}
            </div>
        </div>
    );
}
export default BookLists;
