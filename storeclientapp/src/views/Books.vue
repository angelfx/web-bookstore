<template>
  <div class="books">
    Книги
    <!-- <BooksView /> -->
    <br>
    <router-link to="/books/add">Add new book</router-link>
    <br>
    {{currentDate}}
    {{postResult}}
    <br>
    <table align="center">
      <tr>
        <td>
          <input type="text" v-model="title" placeholder="Enter title of book">
        </td>
        <td>
          <input type="text" v-model="author" placeholder="Enter author of book">
        </td>
        <td>
          <select v-model="type">
            <option value="All" selected="selected">All</option>
            <option value="eBook">eBook</option>
            <option value="Paper book">Paper book</option>
          </select>
        </td>
        <td>
          <input type="checkbox" v-model="sale">
        </td>
        <td>
          <lebel>Sale</lebel>
        </td>
        <td>
          <button class="btn btn-dark" v-on:click="search">Search</button>
        </td>
      </tr>
    </table>

    <table class="table" v-if="books">
      <tr>
        <th>Tile</th>
        <th>Author</th>
        <th>Placed Date</th>
        <th>Count</th>
        <th>Type</th>
        <th>Price</th>
      </tr>
      <tr v-for="book in books">
        <td>
          <router-link :to="{ name: 'book', params: {id:Number(book.id)} }">{{ book.title }}</router-link>
        </td>
        <td>{{ book.author }}</td>
        <td>{{ moment(String(book.placedDate)).format('DD.MM.YYYY hh:mm') }}</td>
        <td>{{ book.count }}</td>
        <td>{{ book.type }}</td>
        <td v-if="book.sale">
          SALE.
          <br>
          Old price: {{ book.price }}
          <br>
          New price: {{book.price * 0.75}}
        </td>
        <td v-else>{{ book.price }}</td>
        <td>
          <button class="btn btn-dark" value="delete" v-on:click="delBook(book.id)">Delete book</button>
        </td>
      </tr>
    </table>
  </div>
</template>

<script>
export default {
  name: "books",
  data() {
    return {
      postResult: "",
      books: null,
      title: "",
      author: "",
      type: "All",
      sale: false,
      currentDate: this.moment().format("DD.MM.YYYY HH:mm:ss")
    };
  },
  mounted() {
    this.$http
      .get("api/books/get")
      .then(response => (this.books = response.data));
  },
  methods: {
    search: function() {
      var params = new URLSearchParams();
      params.append("title", this.title);
      params.append("author", this.author);
      if (this.type != "All") params.append("type", this.type);
      params.append("sale", this.sale);
      this.$http.get("api/books/get", { params: params }).then(response => {
        this.books = [];
        this.books = response.data;
        this.currentDate = this.moment().format("DD.MM.YYYY HH:mm:ss");
      });
    },
    delBook: function(id) {
      this.$http
        .delete("api/books/delete/" + id)
        .then(this.search())
        .catch(e => (this.postResult = e));
    }
  }
};
</script>