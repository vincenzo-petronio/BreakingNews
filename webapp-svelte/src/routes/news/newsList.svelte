<script>
	import { onMount } from 'svelte';

	export let news_count;

	let listOfNews = [];

	let counter = 1;

	onMount(async () => {
		const response = await fetch('http://localhost:5002/api/News');
		const data = await response.json();
		console.log(data);
		listOfNews = data;
	});

	function OnRefreshButtonClicked() {
		// listOfNews.push({ title: 'eee', timestamp: '2022-01-05' });
		// listOfNews = listOfNews;
		counter++;
	}
</script>

<h2>List of last {news_count} news</h2>
<ul>
	{#each listOfNews as { title, timestamp }}
		<li>
			{title} [{timestamp}]
		</li>
	{/each}
</ul>

<button on:click={OnRefreshButtonClicked}>Refresh</button>
<input bind:value={counter} />
