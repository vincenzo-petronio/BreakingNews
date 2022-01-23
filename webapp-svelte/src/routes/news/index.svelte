<script>
	import NewsList from './newsList.svelte';

	let newsCount = 10;
</script>

<svelte:head>
	<title>Breaking News made with Svelte</title>
	<!-- <link rel="StyleSheet" href=""> -->
</svelte:head>

<h1>Breaking News</h1>

<label for="id_numnews">Number of news</label>
<input id="id_numnews" bind:value={newsCount} />

<NewsList news_count={newsCount} />

<style>
	h1 {
		color: red;
	}
</style>
