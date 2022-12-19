import { SHOW_HIDE_LIST, ADD_BOOK, REMOVE_ITEM } from './Types';

const BookReducer = (state, action) => {
    switch (action.type) {
        case SHOW_HIDE_LIST: {
            return {
                ...state,
                showBook: !state.showBook,
            };
        }
        case ADD_BOOK: {
            return {
                ...state,
                bookItems: [...state.bookItems, action.payload],
            };
        }
        case REMOVE_ITEM: {
            return {
                ...state,
                bookItems: state.bookItems.filter((item) => item._id !== action.payload),
            };
        }

        default:
            return state;
    }
};

export default BookReducer;
