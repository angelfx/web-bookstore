<template>
  <div class="addbook">
    <div class="container">
      <div class="row">
        <div class="col-sm-2"></div>
        <div class="col-sm-8">
          {{postResult}}
          <span v-if="errors.length" style="text-align:left;">
            <b>Please fix those errors:</b>
            <ul>
              <li v-for="error in errors">{{ error }}</li>
            </ul>
          </span>
          <div class="form-group">
            <label>Title</label>
            <input class="form-control" type="text" v-model="book.title">
          </div>
          <div class="form-group">
            <label>Author</label>
            <input class="form-control" type="text" v-model="book.author">
          </div>
          <div class="form-group">
            <label>Placed Date</label>
            <datepicker :bootstrap-styling="true" v-model="book.placedDate" :format="dateFormat"></datepicker>
          </div>
          <div class="form-group">
            <label>Count</label>
            <input class="form-control" type="number" min="0" v-model="book.count">
          </div>
          <div class="form-group">
            <label>Price</label>
            <input class="form-control" type="number" min="0" v-model="book.price">
            <br>
            <select class="form-control" v-model="book.sale">
              <option value="false">Default price</option>
              <option value="true">Sale (discount is 25% of price)</option>
            </select>
          </div>
          <div class="form-group">
            <label>Type</label>
            <br>
            <div style="text-align:left;">
              <input type="radio" id="eBook" value="eBook" v-model="book.type">
              <label for="eBook">eBook</label>
              <br>
              <input type="radio" id="paperBook" value="Paper book" v-model="book.type">
              <label for="paperBook">Paper book</label>
            </div>
          </div>
          <div class="form-group">
            <label>Descrition</label>
            <textarea class="form-control" type="text" v-model="book.description"></textarea>
          </div>
          <button id="btnAdd" class="btn btn-dark" v-on:click="sendbook">{{btnName}}</button>
        </div>
        <div class="col-sm-2"></div>
      </div>
    </div>
  </div>
</template>

<script>
import Datepicker from "vuejs-datepicker";

export default {
  name: "addbook",
  components: {
    Datepicker
  },
  // props: {
  //   id: Number
  // },
  data() {
    return {
      postResult: "",
      dateFormat: "dd.MM.yyyy",
      errors: [],
      id: Number(this.$route.params.id),
      btnName: "Add book",
      book: {
        title: "",
        author: "",
        placedDate: new Date(),
        count: 0,
        type: "",
        sale: false,
        description: "",
        price: 0,
        id: 0
      }
    };
  },
  mounted() {
    if (this.id > 0) {
      this.getBook();
      this.btnName = "Update book";
    }
  },
  methods: {
    sendbook() {
      this.errors = [];
      if (this.checkForm()) {
        this.postResult = "dddd;";
        this.$http
          .post("api/books/post", this.book)
          .then(response => {
            this.postResult = "dddd;";
            if (response.data == "200") {
              this.postResult =
                "Book successfully added to the database. You can add a new book.";
            }
            if (this.id > 0) {
              this.router.push({ name: "book", params: { id: this.id } });
            } else {
              this.book.title = "";
              this.book.author = "";
              this.book.placedDate = new Date();
              this.book.count = 0;
              this.book.type = "";
              this.book.sale = false;
              this.book.description = "";
              this.book.price = 0;
              this.id = 0;
              this.book.id = 0;
            }
          })
          .catch(e => {
            this.postResult = e;
          });
      }
    },
    checkForm: function() {
      if (
        this.book.title &&
        this.book.author &&
        this.book.placedDate &&
        this.book.count > 0 &&
        this.book.type &&
        this.book.price > 0
      ) {
        return true;
      }

      if (!this.book.title) {
        this.errors.push("Enter a title of book");
      }

      if (!this.book.author) {
        this.errors.push("Enter a author of book");
      }

      if (!this.book.placedDate) {
        this.errors.push("Enter a date of book");
      }

      if (!this.book.count || this.book.count == 0 || this.book.count < 0) {
        this.errors.push("Count of book must be a greater than 0");
      }

      if (!this.book.type) {
        this.errors.push("Select type of book");
      }

      if (!this.book.count || this.book.price == 0 || this.book.price < 0) {
        this.errors.push("Price of book must be a greater than 0");
      }

      return false;
    },
    getBook: function() {
      this.$http
        .get("http://localhost:5564/api/books/get/" + this.id)
        .then(response => (this.book = response.data));
    }
  }
};
</script>