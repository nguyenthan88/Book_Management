import { useReducer } from 'react';
import BookContext from './Context';
import Reducer from './Reducers';
import { SHOW_HIDE_LIST, ADD_BOOK, REMOVE_ITEM } from './Types';

const BookState = ({ children }) => {
    const initalState = {
        showBook: false,
        bookItems: [],
    };

    const [state, dispatch] = useReducer(Reducer, initalState);

    const addBook = (item) => {
        dispatch({ type: ADD_BOOK, payload: item });
    };

    const showHideList = () => {
        dispatch({ type: SHOW_HIDE_LIST });
    };

    const removeItem = (id) => {
        dispatch({ type: REMOVE_ITEM, payload: id });
    };

    return (
        <BookContext.Provider
            value={{
                showBook: state.showBook,
                bookItems: state.bookItems,
                addBook,
                showHideList,
                removeItem,
            }}
        >
            {children}
        </BookContext.Provider>
    );
};

export default BookState;
