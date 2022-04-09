<script context="module">
	export async function load(ctx) {
		const response = await ctx.fetch('https://jsonplaceholder.typicode.com/users');
		const users = await response.json();
		console.log(users);

		return {
			props: {
				users
			}
		};
	}
</script>

<script>
	export let users;
</script>

<h2>SSR</h2>
<div>
	<ul>
		{#each users as user}
			<li>{user.name}</li>
		{/each}
	</ul>
</div>
