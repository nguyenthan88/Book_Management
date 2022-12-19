import * as React from 'react';
import { Routes, Route } from 'react-router-dom';
import './App.css';

import Books from './pages/Admin/Books/Books';
import EditBook from './pages/Admin/Books/EditBook';
import ViewBook from './pages/Admin/Books/ViewBook';
import NewBook from './pages/Admin/Books/NewBook';

import ListBorrowRequest from './pages/Admin/BorrowBookRequest/ListRequest';

import Categories from './pages/Admin/Categories/Categories';
import EditCategory from './pages/Admin/Categories/EditCategory';
import ViewCategory from './pages/Admin/Categories/ViewCategory';
import NewCategory from './pages/Admin/Categories/NewCategory';

// import Navbar from './components/Navbar/Navbar';
// import Home from './pages/Home/Home';
import Login from './components/Login/Login';
import Home from './pages/Home/Home';
function App() {
    return (
        <div className="App">
            <Routes>
                <Route path="" element={<Login />} />
                <Route path="/home" element={<Home />} />
                <Route path="/borrowrequest" element={<ListBorrowRequest />} />
                <Route path="/category" element={<Categories />} />
                <Route path="/category/new" element={<NewCategory title="Add New Category" />} />
                <Route path="/category/editcategory/:categoryId" element={<EditCategory title="Edit Category" />} />
                <Route path="/category/viewcategory/:categoryId" element={<ViewCategory title="Category Details" />} />
                <Route path="/book" element={<Books />} />
                <Route path="/book/new" element={<NewBook title="Add New Book" />} />
                <Route path="/book/editbook/:bookId" element={<EditBook title="Edit Book" />} />
                <Route path="/book/viewbook/:bookId" element={<ViewBook title="Book Details" />} />
                <Route path="/logout" element={<Login />} />
            </Routes>
        </div>
    );
}

export default App;
