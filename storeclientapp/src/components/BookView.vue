<template>
  <div class="bookview">
    {{postResult}}
    <br>
    <router-link
      :to="{ name: 'updatebook', params: {id:this.id} }"
      class="btn btn-primary"
    >Edit this book</router-link>
    <dl v-if="book">
      <dt>Title</dt>
      <dd>{{book.title}}</dd>
      <dt>Author</dt>
      <dd>{{book.author}}</dd>
      <dt>Placed dateя</dt>
      <dd>{{moment(String(book.placedDate)).format('DD.MM.YYYY hh:mm')}}</dd>
      <dt>Count</dt>
      <dd>{{book.count}}</dd>
      <dt>Type</dt>
      <dd>{{book.type}}</dd>
      <dt>Price</dt>
      <dd v-if="book.sale">
        SALE.
        <br>
        Old price: {{ book.price }}
        <br>
        New price: {{book.price * 0.75}}
      </dd>
      <dd v-else>{{ book.price }}</dd>
      <dt v-if="book.description">Decription</dt>
      <dd v-if="book.description">{{book.description}}</dd>
    </dl>
    <div class="container">
      <div class="row">
        <div class="col-sm-2"></div>
        <div class="col-sm-8">
          <div class="form-group">
            <label>Count</label>
            <input class="form-control" type="number" v-model="addCnt">
          </div>
          <button id="btnAdd" class="btn btn-dark" v-on:click="addcount">Add count to book</button>
        </div>
        <div class="col-sm-2"></div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "bookview",
  props: {
    id: Number
  },
  data() {
    return {
      addCnt: 0,
      postResult: "",
      book: null
    };
  },
  mounted() {
    this.getBook();
  },
  methods: {
    addcount: function() {
      var params = new URLSearchParams();
      params.append("count", this.addCnt);
      this.postResult = "dddd";
      this.$http
        .post("api/books/AddCount/" + this.id, params)
        .then(response => {
          if (response.data == "200") {
            this.postResult = "Book successfully updated.";
            this.getBook();
          }
        })
        .catch(e => {
          this.postResult = e;
        });
    },
    getBook: function() {
      this.$http
        .get("api/books/get/" + this.id)
        .then(response => (this.book = response.data));
    }
  }
};
</script>