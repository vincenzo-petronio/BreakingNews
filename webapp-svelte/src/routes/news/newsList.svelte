<script>
	import { onMount } from 'svelte';

	// export let news_count = 10;

	let listOfNews = [];
	let counter = 1;

	onMount(async () => {
		const response = await fetch('http://localhost:5002/api/News');
		const data = await response.json();
		console.log(data);
		listOfNews = data;
		// listOfNews.slice()
	});

	function OnRefreshButtonClicked() {
		// listOfNews.push({ title: 'eee', timestamp: '2022-01-05' });
		// listOfNews = listOfNews;
		counter++;
	}
</script>

<h4>List of last news</h4>
<ul>
	{#each listOfNews as { title, timestamp }}
		<li>
			{title} [{timestamp}]
		</li>
	{/each}
</ul>

<button class="btn btn-primary" on:click={OnRefreshButtonClicked}>Refresh</button>
<!-- <input bind:value={counter} /> -->
