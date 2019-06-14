<template>
  <div class="hello">
    <div class="container">
      <div class="row">
        <div class="col-sm-2"></div>
          <div class="col-sm-8">
            <h1>{{ msg }}</h1>
            <p>We want to store and sale our old books and we need to manage this process.
              <br>We can to:
              <ul>
                <li>Add a new book</li>
                <li>Update book</li>
                <li>Delete book</li>
                <li>Find book by some criterias</li>
                <li>Change count of book in our store</li>
                <li>Manage prices and discounts of books</li>
              </ul>
            </p>
            <p>In the future we will sale books from this apps. In backend we have order entity and some logic for this task.</p>
          </div>
        </div>
      </div>
      <div class="col-sm-2"></div>
  </div>
</template>

<script>
export default {
  name: "HelloWorld",
  props: {
    msg: String
  }
};
</script>

<style scoped>
h3 {
  margin: 40px 0 0;
}
p {
  text-align: left;
}
a {
  color: #42b983;
}
</style>
