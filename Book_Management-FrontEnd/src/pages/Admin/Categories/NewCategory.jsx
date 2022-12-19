import '../Scss/New.scss';
import Button from '@mui/material/Button';
import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

function NewCategory({ title }) {
    const [categories, setCategories] = useState([]);
    const [categoryName, setCategoryName] = useState([]);
    const [description, setDescription] = useState([]);
    const [addResult, setAddResult] = useState(false);

    const history = useNavigate();

    function handleClick(e) {
        e.preventDefault();
        history('/category');
    }

    const addCategory = async () => {
        if (categoryName != null) {
            try {
                const response = await fetch(`https://localhost:7233/Category`, {
                    method: 'POST',
                    body: JSON.stringify({
                        categoryName: categoryName,
                        description: description,
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
                                    <input hidden value={categories.CategoryId} />
                                    <label>Category Name</label>
                                    <input onChange={(e) => setCategoryName(e.target.value)} />
                                    <label>Description</label>
                                    <input onChange={(e) => setDescription(e.target.value)} />
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
                                    Back To Category
                                </Button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default NewCategory;
