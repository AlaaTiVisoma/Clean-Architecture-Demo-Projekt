<template>
    <div>
        <button @click="fetchBooks">Load Books</button>
        <table v-if="books.length">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Title</th>
                    <th>Author</th>
                    <th>Price</th>
                    <th>Published Date</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="book in books" :key="book.id">
                    <td>{{ book.id }}</td>
                    <td>{{ book.title }}</td>
                    <td>{{ book.author }}</td>
                    <td>{{ book.finalPrice }}</td>
                    <td>{{ book.publishedDate }}</td>
                </tr>
            </tbody>
        </table>
        <p v-else>No books available</p>
    </div>
</template>

<script lang="ts" setup>
    import { ref } from 'vue';
    import axios from 'axios';

    // Define a type for the book data
    interface Book {
        id: number;
        title: string;
        author: string;
        finalPrice: number;
        publishedDate: string;
    }

    // Define a ref to hold the book data
    const books = ref<Book[]>([]);

    // Define a function to fetch books from the API
    const fetchBooks = async () => {
        try {
            const response = await axios.get('http://localhost:5000/api/books'); // Adjust API URL if needed
            books.value = response.data;
        } catch (error) {
            console.error('Failed to fetch books:', error);
        }
    };
</script>

<style scoped>
    table {
        width: 100%;
        border-collapse: collapse;
    }

    th, td {
        border: 1px solid #ddd;
        padding: 8px;
        text-align: left;
    }

    th {
        background-color: #f4f4f4;
    }

    button {
        margin-bottom: 10px;
        padding: 8px 16px;
        background-color: #007bff;
        color: white;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

        button:hover {
            background-color: #0056b3;
        }
</style>
