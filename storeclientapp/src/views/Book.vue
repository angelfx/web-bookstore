<template>
  <div class="book">
     Книга {{idBook}}
    <BookView :id="idBook" />
  </div>
</template>

<script>
// @ is an alias to /src
import BookView from '@/components/BookView.vue'

export default {
  name: 'book',
  data () {
      return {
          idBook: Number(this.$route.params.id)
      }
  },
  components: {
    BookView
  }
}
</script>