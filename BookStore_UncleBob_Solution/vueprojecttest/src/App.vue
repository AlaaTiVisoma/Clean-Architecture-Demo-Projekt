<template>
    <div id="app">
        <h1>Book Store</h1>
        <VueBooks />
    </div>
</template>

<script lang="ts" setup>
    import VueBooks from './components/VueBooks.vue';
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }

    h1 {
        color: #42b983;
    }
</style>
