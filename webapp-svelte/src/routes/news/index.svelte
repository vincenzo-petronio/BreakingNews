<script>
	import NewsList from './newsList.svelte';
	import NewsForm from './newsForm.svelte';

	// let newsCount = 2;
</script>

<svelte:head>
	<title>Breaking News made with Svelte</title>
	<!-- <link rel="StyleSheet" href=""> -->
</svelte:head>

<h1>Breaking News</h1>

<!-- <label for="id_numnews">Number of news</label> -->
<!-- <input id="id_numnews" bind:value={newsCount} /> -->

<div class="row g-4">
	<div class="col-md-6"><NewsForm /></div>
	<div class="col-md-6"><NewsList /></div>
</div>


<style>
	h1 {
		color: red;
	}
</style>
